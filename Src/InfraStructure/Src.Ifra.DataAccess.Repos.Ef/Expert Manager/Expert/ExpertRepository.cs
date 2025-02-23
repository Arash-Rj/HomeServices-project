using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Ifra.DataAccess.Repos.Ef.Expert_Manager.Expert
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly AppDbContext _appDbContext;
        public ExpertRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Result> Create(AppExpert objct, CancellationToken cancellationToken)
        {
            try
            {
                await _appDbContext.Users.AddAsync(objct, cancellationToken);
                var res = _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "ثبت نام با موفقیت انجام شد.");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var expert = _appDbContext.AppExperts.SingleOrDefault(x => x.Id == id);
                if (expert == null)
                    return new Result(false, "کارشناسی با این ایدی پیدا نشد!");
                expert.IsActive = false;
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "حذف با موفقیت انجام شد.");
        }

        public async Task<ExpertDto?> GetInfo(int id, CancellationToken cancellationToken)
        {
            var expertdto = new ExpertDto();
            try
            {
               var expert = await _appDbContext.AppExperts
                    .Select(e => new { e.Id, e.UserName, e.PhoneNumber, e.Email, e.Proposals.Count, e.Province })
                    .FirstAsync(u => u.Id.Equals(id), cancellationToken);
                expertdto.Id = expert.Id;
                expertdto.Email = expert.Email;
                expertdto.Phone = expert.PhoneNumber;
                expertdto.Name = expert.UserName;
                expertdto.Province = expert.Province;
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return expertdto;
            }
            return expertdto;
        }

        public async Task<List<ExpertDto>?> GetAllInfo(CancellationToken cancellationToken)
        {
            var expertdtos = new List<ExpertDto>();
            try
            {
               var exprets = await _appDbContext.AppExperts.Where(c => c.IsActive == true)
                    .Select(e => new {e.Id , e.UserName , e.PhoneNumber , e.Email , e.Proposals.Count , e.Province})
                    .ToListAsync(cancellationToken);
                foreach (var expert in exprets)
                {
                    var expertdto = new ExpertDto
                    {
                        Id = expert.Id,
                        Name = expert.UserName,
                        Phone = expert.PhoneNumber,
                        Email = expert.Email,
                        ProposalCount = expert.Count,
                        Province = expert.Province
                    };
                    expertdtos.Add(expertdto);
                }
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return expertdtos;
        }

        public async Task<Result> Update(UpdateExpertDto objct, CancellationToken cancellationToken)
        {
            try
            {
                var expert = await _appDbContext.AppExperts.FirstOrDefaultAsync(c => c.Id == objct.Id);
                if (expert == null)
                    return new Result(false, "کارشناس با این ایدی پیدا نشد!");
                expert.UserName = objct.Name;
                expert.Email = objct.Email;
                expert.PhoneNumber = objct.Phone;
                expert.Province = objct.Province;
                expert.Bioghraphy = objct.Bioghraphy;
                expert.CardNumber = objct.CardNumber;
                expert.WorkPlaceAddress = objct.WorkPlaceAddress;
                expert.IsActive = objct.IsActive;
                var res = await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true, "تغییر کارشناس با موفقیت انجام شد.");
        }

        public async Task<UpdateExpertDto?> GetDetailedInfo(int id, CancellationToken cancellationToken)
        {
            var updateExpertdto = new UpdateExpertDto();
            try
            {
                var expert = await _appDbContext.AppExperts
                     .Select(e => new { e.Id, e.UserName, e.PhoneNumber, e.Email,
                         e.CardNumber, e.Province , e.Bioghraphy , e.IsActive , e.WorkPlaceAddress })
                     .FirstAsync(u => u.Id.Equals(id), cancellationToken);
                #region Mapping
                updateExpertdto.Id = expert.Id;
                updateExpertdto.Email = expert.Email;
                updateExpertdto.Phone = expert.PhoneNumber;
                updateExpertdto.Name = expert.UserName;
                updateExpertdto.Province = expert.Province;
                updateExpertdto.CardNumber = expert.CardNumber;
                updateExpertdto.WorkPlaceAddress = expert.WorkPlaceAddress;
                updateExpertdto.Bioghraphy = expert.Bioghraphy;
                updateExpertdto.IsActive = expert.IsActive;
                #endregion
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return updateExpertdto;
            }
            return updateExpertdto;
        }
    }
}
