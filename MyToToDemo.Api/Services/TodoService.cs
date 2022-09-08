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
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TodoService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(ToDoDto model)
        {
            try
            {
                var todo = mapper.Map<ToDo>(model);
                await unitOfWork.GetRepository<ToDo>().InsertAsync(todo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, model);
                }
                else
                {
                    return new ApiResponse(false, "增加数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false,ex.ToString());
            }
           
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: s => s.Id.Equals(id));

                if (todo == null) return new ApiResponse(false, "删除的数据不存在！");

                repository.Delete(todo);

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

        public async Task<ApiResponse> GetAllAsync(ToDoParameter query)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todos = await repository.GetPagedListAsync(s=> string.IsNullOrWhiteSpace(query.Search) ? true : s.Title.Contains(query.Search) && (query.Status == null ? true : s.Status.Equals(query.Status)),
                    pageIndex:query.PageIndex,
                    pageSize:query.PageSize,
                    orderBy:param => param.OrderByDescending(t=>t.CreateTime));

                if (todos.Items.Count == 0) return new ApiResponse(false, "未查询到任何数据！");
                return new ApiResponse(true, todos);
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
                var repository = unitOfWork.GetRepository<ToDo>();
                var todos = await repository.GetPagedListAsync(s => string.IsNullOrWhiteSpace(query.Search) ? true : s.Title.Contains(query.Search),
                    pageIndex: query.PageIndex,
                    pageSize: query.PageSize,
                    orderBy: param => param.OrderByDescending(t => t.CreateTime));

                if (todos.Items.Count == 0) return new ApiResponse(false, "未查询到任何数据！");
                return new ApiResponse(true, todos);
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
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: s => s.Id.Equals(id));

                if (todo == null) return new ApiResponse(false, "查询的数据不存在！");

                return new ApiResponse(true, todo);
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.ToString());
            }
            
        }

        public async Task<ApiResponse> UpdateAsync(ToDoDto model)
        {
            try
            {
                var dto = mapper.Map<ToDo>(model);
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: s => s.Id.Equals(dto.Id));

                if (todo == null) return new ApiResponse(false, "更新的数据不存在！");

                repository.Update(todo);

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
