using CustomerApi.Data;
using Microsoft.AspNetCore.Mvc;
using CustomerApi.Dto;
using CustomerApi.Mappers;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet(Name = "GetCustomers")]
        public IEnumerable<CustomerDto> Get()
        {
            return JsonHelper.ReadFromJsonFile<Customer>().Select(s => s.ToCustomerDto());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customers = JsonHelper.ReadFromJsonFile<Customer>();
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] CreateCustomerRequestDto customerDto)
        {
            int maxId = 0;
            var customerModel = customerDto.ToCustomerFromCreateDto();
            var customers = JsonHelper.ReadFromJsonFile<Customer>();

            //Assign new ID as max + 1 to avoid duplicates
            if(customers.Count > 0)
            {
                maxId = customers.OrderByDescending(c => c.Id).FirstOrDefault().Id;
            }
            else
            {
                maxId = 0;
            }

            customerModel.Id = maxId + 1;
            customers.Add(customerModel);

            JsonHelper.WriteToJsonFile(customers);

            //Auto-increment Id not working, possibly because no database is used
            return CreatedAtAction(nameof(GetCustomer), new { id = customerModel.Id }, customerModel.ToCustomerDto());
        }

        [HttpPut("{id}")]
        public ActionResult<Customer> Update(int id, [FromBody] Customer updatedCustomer)
        {
            var customers = JsonHelper.ReadFromJsonFile<Customer>();
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = updatedCustomer.Name;
            customer.Company = updatedCustomer.Company;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
            customer.Email = updatedCustomer.Email;
            customer.Address = updatedCustomer.Address;
            customer.Updated = DateTime.Now;

            JsonHelper.WriteToJsonFile(customers);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            var customers = JsonHelper.ReadFromJsonFile<Customer>();
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            customers.Remove(customer);
            JsonHelper.WriteToJsonFile(customers);
            return NoContent();
        }
    }
}
