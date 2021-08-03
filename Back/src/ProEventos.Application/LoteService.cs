using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.DTOs;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System.Linq;

namespace ProEventos.Application
{
    /// <summary>
    /// Responsible to mediate the interaction, relative to the records of Lote,
    /// between the API and the Persistence layers. Here are the auto-mappings
    /// been done.
    /// </summary>
    public class LoteService : ILoteService
    {
        /// <summary>
        /// Used to make a reference to the class ProEventos.Persistence.GeneralPersistence
        /// </summary>
        private readonly IGeneralPersistence _generalPersistence;

        /// <summary>
        /// Used to make a reference to the class ProEventos.Persistence.LotePersistence
        /// </summary>
        private readonly ILotePersistence _lotePersistence;

        /// <summary>
        /// Used to make a reference to the class AutoMapper.IMapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Receives a dependency injection of objects of type
        /// ProEventos.Persistence.GeneralPersistence,
        /// ProEventos.Persistence.LotePersistence and AutoMapper.IMapper
        /// </summary>
        /// <param name="generalPersistence">Object of type ProEventos.Persistence.GeneralPersistence</param>
        /// <param name="lotePersistence">Object of type ProEventos.Persistence.LotePersistence</param>
        /// <param name="mapper">Object of type AutoMapper.IMapper</param>
        public LoteService(
            IGeneralPersistence generalPersistence,
            ILotePersistence lotePersistence,
            IMapper mapper
            )
        {
            this._generalPersistence = generalPersistence;
            this._lotePersistence = lotePersistence;
            this._mapper = mapper;
        }

        public async Task<bool> DeleteLote(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersistence.GetLoteByEventoIdAsync(eventoId, loteId);
                if(lote == null) throw new Exception("Can't found the Lote record to delete...");

                _generalPersistence.Delete<Lote>(lote);
                return await _generalPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoteDto> GetLoteByEventoIdAsync(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersistence.GetLoteByEventoIdAsync(eventoId, loteId);
                if(lote == null) return null;

                var resultado = _mapper.Map<LoteDto>(lote);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId)
        {
            try
            {
                var lotes = await _lotePersistence.GetLotesByEventoIdAsync(eventoId);
                if(lotes == null) return null;

                var resultado = _mapper.Map<LoteDto[]>(lotes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddLote(int eventoId, LoteDto model)
        {
            try
            {
                var lote = _mapper.Map<Lote>(model);
                lote.EventoId = eventoId;

                _generalPersistence.Add<Lote>(lote);

                await _generalPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoteDto[]> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _lotePersistence.GetLotesByEventoIdAsync(eventoId);
                if(lotes == null) return null;

                foreach (var model in models)
                {
                    if(model.EventoId == 0) {
                        await AddLote(eventoId, model);
                    } else {
                        var lote = lotes.FirstOrDefault(lote => lote.Id == model.Id);
                        model.EventoId = eventoId;
                        _mapper.Map(model, lote);
                        _generalPersistence.Update<Lote>(lote);
                        await _generalPersistence.SaveChangesAsync();
                    }
                }

                var lotesRetorno = await _lotePersistence.GetLotesByEventoIdAsync(eventoId);

                return _mapper.Map<LoteDto[]>(lotesRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}