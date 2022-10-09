using AutoMapper;
using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToToDemo.Api.Context.UnitOfWork;
using MyToToDemo.Api.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Services
{
    public class MemoService : IMemoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MemoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(MemoDto model)
        {
            try
            {
                var memo = mapper.Map<Memo>(model);
                await unitOfWork.GetRepository<Memo>().InsertAsync(memo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, memo);
                }
                else
                {
                    return new ApiResponse(false, "增加数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.ToString());
            }

        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: s => s.Id.Equals(id));

                if (memo == null) return new ApiResponse(false, "删除的数据不存在！");

                repository.Delete(memo);

                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, "删除数据成功！");
                }
                else
                {
                    return new ApiResponse(false, "删除数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.ToString());
            }

        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter query)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Memo>();
                var memos = await repository.GetPagedListAsync(s => string.IsNullOrWhiteSpace(query.Search) ? true : s.Title.Contains(query.Search),
                    pageIndex: query.PageIndex,
                    pageSize: query.PageSize,
                    orderBy: param => param.OrderByDescending(t => t.CreateTime));

                if (memos.Items.Count == 0) return new ApiResponse(false, "未查询到任何数据！");
                return new ApiResponse(true, memos);
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.ToString());
            }

        }


        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: s => s.Id.Equals(id));

                if (memo == null) return new ApiResponse(false, "查询的数据不存在！");

                return new ApiResponse(true, memo);
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.ToString());
            }

        }

        public async Task<ApiResponse> UpdateAsync(MemoDto model)
        {
            try
            {
                var memo = mapper.Map<Memo>(model);
                var repository = unitOfWork.GetRepository<Memo>();
                memo = await repository.GetFirstOrDefaultAsync(predicate: s => s.Id.Equals(memo.Id));

                if (memo == null) return new ApiResponse(false, "更新的数据不存在！");

                repository.Update(memo);

                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, "更新数据成功！");
                }
                else
                {
                    return new ApiResponse(false, "更新数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.ToString());
            }
        }
    }
}
