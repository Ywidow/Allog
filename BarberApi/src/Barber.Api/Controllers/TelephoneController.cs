using AutoMapper;
using Barber.Api.DbContexts;
using Barber.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Barber.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Barber.Api.Entities;

namespace Barber.Api.Controllers;

[ApiController]
[Route("api/customers/{customerId}/telephones")]
public class TelephoneController : ControllerBase{
  private readonly IMapper _mapper;
  private readonly ICustomerRepository _customerRepository;

  public TelephoneController(IMapper mapper, ICustomerRepository customerRepository)
  {
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
  }


  // Gets:
  [HttpGet("{telephoneId}", Name = "GetTelephoneById")]
  public async Task<ActionResult<TelephoneToReturnDto>> GetTelephoneById(int customerId, int telephoneId){
    var telephoneFromDatabase = await _customerRepository.GetTelephoneById(customerId, telephoneId);

    if(telephoneFromDatabase == null) return NotFound();

    var telephoneToReturn = _mapper.Map<TelephoneToReturnDto>(telephoneFromDatabase);

    return Ok(telephoneToReturn);
  }


  // Posts:
  [HttpPost]
  public async Task<ActionResult<TelephoneToReturnDto>> CreateTelephone(int customerId, TelephoneToCreateDto telephoneToCreateDto){
    var customerFromDatabase = await _customerRepository.GetCustomerWithTelephonesById(customerId);

    if(customerFromDatabase == null) return NotFound();

    var telephoneToAdd = _mapper.Map<Telephone>(telephoneToCreateDto);

    _customerRepository.AddTelephone(customerFromDatabase, telephoneToAdd);
    await _customerRepository.SaveChangesAsync();

    var telephoneToReturn = _mapper.Map<TelephoneToReturnDto>(telephoneToAdd);

    return CreatedAtRoute(
      "GetTelephoneById",
      new { customerId, telephoneId = telephoneToReturn.Id },
      telephoneToReturn
    );
  }


  // Puts:
  [HttpPut("{telephoneId}")]
  public async Task<ActionResult> UpdateTelephone(int customerId, int telephoneId, TelephoneToUpdateDto telephoneToUpdateDto){
    if(telephoneId != telephoneToUpdateDto.Id) return NotFound();

    var telephoneFromDatabase = await _customerRepository.GetTelephoneById(customerId, telephoneId);

    if(telephoneFromDatabase == null) return NotFound();

    _customerRepository.UpdateTelephone(telephoneFromDatabase, telephoneToUpdateDto);
    await _customerRepository.SaveChangesAsync();

    return NoContent();
  }
}