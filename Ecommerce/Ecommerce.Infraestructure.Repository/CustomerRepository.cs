using Dapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Infraestructure.Interface;
using Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Ecommerce.Infraestructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Metodos sincronos
        public bool Insert(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(qry, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(qry, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customer Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var customer = connection.QuerySingle<Customer>(qry, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public IEnumerable<Customer> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersList";

                var customers = connection.Query<Customer>(qry, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = connection.Execute(qry, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        #endregion

        #region Metodos asincronos

        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = await connection.ExecuteAsync(qry, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersList";

                var customers = await connection.QueryAsync<Customer>(qry, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var customer = await connection.QuerySingleAsync<Customer>(qry, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public async Task<bool> InsertAsync(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(qry, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var qry = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(qry, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        #endregion
    }
}
