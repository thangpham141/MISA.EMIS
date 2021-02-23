using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Common.Models;
using MISA.Service.Interfaces;

namespace MISA.FeeManagement.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeesController : BasesController<Fee>
    {
        public FeesController(IFeeService feeService) : base(feeService)
        {

        }
    }
}
