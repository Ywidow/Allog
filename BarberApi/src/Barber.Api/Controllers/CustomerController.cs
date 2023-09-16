using AutoMapper;
using Barber.Api.DbContexts;
using Barber.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Barber.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Barber.Api.Entities;

namespace Barber.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase{
  private readonly IMapper _mapper;
  private readonly ICustomerRepository _customerRepository;

  public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
  {
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
  }


  // Gets:
  [HttpGet]
  public async Task<ActionResult<IEnumerable<CustomerToReturnDto>>> GetAllCustomers(){
    var customersFromDatabase = await _customerRepository.GetAllCustomers();

    if(customersFromDatabase == null) return NotFound();

    var customersToReturn = _mapper.Map<IEnumerable<CustomerToReturnDto>>(customersFromDatabase);

    return Ok(customersToReturn);
  }

  [HttpGet("{customerId}")]
  public async Task<ActionResult<CustomerToReturnDto>> GetCustomerById(int customerId){
    var customerFromDatabase = await _customerRepository.GetCustomerById(customerId);

    if(customerFromDatabase == null) return NotFound();

    var customerToReturn = _mapper.Map<CustomerToReturnDto>(customerFromDatabase);

    return Ok(customerToReturn);
  }

  [HttpGet("with-telephones")]
  public async Task<ActionResult<CustomerWithTelephonesToReturnDto>> GetCustomersWithTelephones(){
    var customersFromDatabase = await _customerRepository.GetAllCustomersWithTelephones();

    if(customersFromDatabase == null) return NotFound();

    var customerToReturn = _mapper.Map<IEnumerable<CustomerWithTelephonesToReturnDto>>(customersFromDatabase);

    return Ok(customerToReturn);
  }

  [HttpGet("with-addresses-and-telephones/{customerId}", Name = "GetCustomerWithAddressesAndTelephonesById")]
  public async Task<ActionResult<CustomerWithTelephonesAndAddressesToReturnDto>> GetCustomerWithAddressesAndTelephonesById(int customerId){
    var customerFromDatabase = await _customerRepository.GetCustomerWithAddressesAndTelephonesById(customerId);

    if(customerFromDatabase == null) return NotFound();

    var customerToReturn = _mapper.Map<CustomerWithTelephonesAndAddressesToReturnDto>(customerFromDatabase);

    return Ok(customerToReturn);
  }


  // Posts:
  [HttpPost]
  public async Task<ActionResult<CustomerToReturnDto>> CreateNewCustomer(CustomerToCreateDto customerToCreateDto){
    var customerToAddInDatabase = _mapper.Map<Customer>(customerToCreateDto);

    _customerRepository.AddCustomer(customerToAddInDatabase);
    await _customerRepository.SaveChangesAsync();

    var customerToReturn = _mapper.Map<CustomerWithTelephonesAndAddressesToReturnDto>(customerToAddInDatabase);

    return CreatedAtRoute(
      "GetCustomerWithAddressesAndTelephonesById",
      new { customerId = customerToReturn.Id },
      customerToReturn
    );
  }


  // Deletes:
  [HttpDelete("{customerId}")]
  public async Task<ActionResult> DeleteCustomer(int customerId){
    var customerFromDatabase = await _customerRepository.GetCustomerById(customerId);

    if(customerFromDatabase == null) return NotFound();

    _customerRepository.DeleteCustomer(customerFromDatabase);
    await _customerRepository.SaveChangesAsync();

    return NoContent();
  }

  [HttpDelete("with-addresses-and-telephones/{customerId}")]
  public async Task<ActionResult> DeleteTelephonesAndAddressFromCustomer(int customerId){
    var customerFromDatabase = await _customerRepository.GetCustomerWithAddressesAndTelephonesById(customerId);

    if(customerFromDatabase == null) return NotFound();

    _customerRepository.DeleteAddressesAndTelephones(customerFromDatabase);
    await _customerRepository.SaveChangesAsync();

    return NoContent();
  }


  // Updates:
  [HttpPut("{customerId}")]
  public async Task<ActionResult> UpdateCustomer(int customerId, CustomerToUpdate customerToUpdate){
    var customerFromDatabase = await _customerRepository.GetCustomerById(customerId);
    
    if(customerFromDatabase == null || customerFromDatabase.Id != customerToUpdate.Id) return NotFound();

    _customerRepository.UpdateCustomer(customerFromDatabase, customerToUpdate);
    await _customerRepository.SaveChangesAsync();

    return NoContent();
  }
}
