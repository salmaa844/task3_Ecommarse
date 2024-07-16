using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private IUnitOfWork<Categories> UnitOfWork;
       // private readonly IGenricRepositorycs<Categories> genricRepositorycs;

        public CategoryController(AppDbContext dbContext,IUnitOfWork<Categories> unitOfWork) {
            this.dbContext = dbContext;
            this.UnitOfWork = unitOfWork;

           // this.genricRepositorycs = genricRepositorycs;
        }

    }
}
