using CustomerApi.Dto;

namespace CustomerApi.Mappers
{
    public static class CustomerMappers
    {
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Company = customerModel.Company,
                PhoneNumber = customerModel.PhoneNumber,
                Email = customerModel.Email,
                Address = customerModel.Address,
                Updated = customerModel.Updated,
                Created = customerModel.Created
            };
        }

        public static Customer ToCustomerFromCreateDto(this CreateCustomerRequestDto customerDto)
        {
            return new Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Company = customerDto.Company,
                PhoneNumber = customerDto.PhoneNumber,
                Email = customerDto.Email,
                Address = customerDto.Address,
                Updated = customerDto.Updated,
                Created = customerDto.Created
            };
        }
    }
}
