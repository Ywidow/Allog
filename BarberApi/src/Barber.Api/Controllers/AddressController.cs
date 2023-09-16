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
public class AddressController : ControllerBase{
  private readonly IMapper _mapper;
  private readonly ICustomerRepository _customerRepository;

  public AddressController(IMapper mapper, ICustomerRepository customerRepository)
  {
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
  }


  // Gets:
  [HttpGet("{addressId}", Name = "GetAddressById")]
  public async Task<ActionResult<AddressToReturnDto>> GetAddressById(int customerId, int addressId){
    var addressFromDatabase = await _customerRepository.GetAddressById(customerId, addressId);

    if(addressFromDatabase == null) return NotFound();

    var addressToReturn = _mapper.Map<AddressToReturnDto>(addressFromDatabase);

    return Ok(addressToReturn);
  }

  
  // Posts:
  [HttpPost]
  public async Task<ActionResult<AddressToReturnDto>> CreateAddress(int customerId, AddressToCreateDto addressToCreateDto){
    var customerFromDatabase = await _customerRepository.GetCustomerWithAddressesById(customerId);

    if(customerFromDatabase == null) return NotFound();

    var addressToAdd = _mapper.Map<Address>(addressToCreateDto);

    _customerRepository.AddAddress(customerFromDatabase, addressToAdd);
    await _customerRepository.SaveChangesAsync();

    var addressToReturn = _mapper.Map<AddressToReturnDto>(addressToAdd);

    return CreatedAtRoute(
      "GetAddressById",
      new { customerId, addressId = addressToReturn.Id },
      addressToReturn
    );
  }


  // Puts:
  [HttpPut("{addressId}")]
  public async Task<ActionResult> UpdateAddress(int customerId, int addressId, AddressToUpdateDto addressToUpdateDto){
    if(addressId != addressToUpdateDto.Id) return NotFound();

    var addressFromDatabase = await _customerRepository.GetAddressById(customerId, addressId);

    if(addressFromDatabase == null) return NotFound();

    _customerRepository.UpdateAddress(addressFromDatabase, addressToUpdateDto);
    await _customerRepository.SaveChangesAsync();

    return NoContent();
  }
}