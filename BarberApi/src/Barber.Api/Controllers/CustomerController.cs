using AutoMapper;
using Barber.Api.DbContexts;
using Barber.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barber.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase{
  private readonly CustomerContext _context;
  private readonly IMapper _mapper;

  public CustomerController(CustomerContext context, IMapper mapper)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  [HttpGet]
  public async Task<ActionResult<CustomerToReturnDto>> GetAllCustomers(){
    var customersFromDatabase = await _context
      .Customers
      .Include(customer => customer.Orders)
      .Include(customer => customer.Telephones)
      .Include(customer => customer.Addresses)
      .Include(customer => customer.Schedulings)
      .ToListAsync();
    
    var customersToReturn = _mapper.Map<IEnumerable<CustomerToReturnDto>>(customersFromDatabase);

    return Ok(customersToReturn);
  }
}