using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Application.Contratos;
using EstruturaOrganizacional.Domain;
using EstruturaOrganizacional.Persistence.Contratos;

namespace EstruturaOrganizacional.Application
{

    public class BusinessAreaService : IBusinessAreaService
    {
        private readonly IGeralPersist _geralPersist;
        private  readonly IBusinessAreaPersist _businessAreaPersist;
        public BusinessAreaService(IGeralPersist geralPersist, IBusinessAreaPersist businessAreaPersist)
        {
            _businessAreaPersist = businessAreaPersist;
            _geralPersist = geralPersist;
        }
        public async Task<BusinessArea> AddBusinessArea(BusinessArea model)
        {
            try
            {
                _geralPersist.Add<BusinessArea>(model);
                if(await _geralPersist.SaveChangesAsyncs())
                {
                    return await _businessAreaPersist.GetAllBusinessAreaByIdAsync(model.id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }
        public async Task<BusinessArea> UpdateBusinessArea(int id, BusinessArea model)
        {
            try
            {
                var businessarea = await _businessAreaPersist.GetAllBusinessAreaByIdAsync(id);
                if(businessarea == null) return null;

                model.id = businessarea.id;

                _geralPersist.Update(model);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    return await _businessAreaPersist.GetAllBusinessAreaByIdAsync(model.id);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var businessarea = await _businessAreaPersist.GetAllBusinessAreaByIdAsync(id);
                if(businessarea == null) throw new Exception ("A area de negocio não foi encontrada!");

                _geralPersist.Delete<BusinessArea>(businessarea);

                return await _geralPersist.SaveChangesAsyncs();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<BusinessArea[]> GetAllBusinessAreaAsync(bool includeUnidad = false)
        {
            try
            {
                var businessarea = await _businessAreaPersist.GetAllBusinessAreaAsync(includeUnidad);
                if( businessarea == null )return null;

                return businessarea;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BusinessArea[]> GetAllBusinessAreaBySiglaAsync(string sigla, bool includeUnidade = false)
        {
            try
            {
                var businessarea = await _businessAreaPersist.GetAllBusinessAreaBySiglaAsync(sigla,includeUnidade);
                if( businessarea == null )return null;

                return businessarea;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BusinessArea> GetAllBusinessAreaByIdAsync(int id, bool includeUnidade = false)
        {
            try
            {
                var businessarea = await _businessAreaPersist.GetAllBusinessAreaByIdAsync(id, includeUnidade);
                if( businessarea == null )return null;

                return businessarea;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }
    }
}