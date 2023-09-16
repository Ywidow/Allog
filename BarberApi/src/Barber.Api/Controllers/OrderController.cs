using AutoMapper;
using Barber.Api.DbContexts;
using Barber.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Barber.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Barber.Api.Entities;

namespace Barber.Api.Controllers;

[ApiController]
[Route("api/customers/{customerId}/addresses")]
public class OrderController : ControllerBase{
  private readonly CustomerContext _context;
  private readonly IMapper _mapper;
  private readonly ICustomerRepository _customerRepository;

  public OrderController(CustomerContext context, IMapper mapper, ICustomerRepository customerRepository)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
  }
}