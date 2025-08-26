using PostalServiceApp.Models;

namespace PostalServiceApp.Services;

public interface IPostalService
{
    Task<IEnumerable<PostalCode>> SearchPostalCodesAsync(string searchTerm);
    Task<IEnumerable<Address>> GetAddressesByPostalCodeAsync(string postalCode);
}

public class MockPostalService : IPostalService
{
    private readonly List<PostalCode> _postalCodes;
    private readonly List<Address> _addresses;

    public MockPostalService()
    {
        _postalCodes = new List<PostalCode>
        {
            new() { Code = "10001", City = "New York", State = "NY", Country = "USA" },
            new() { Code = "10002", City = "New York", State = "NY", Country = "USA" },
            new() { Code = "10003", City = "New York", State = "NY", Country = "USA" },
            new() { Code = "90210", City = "Beverly Hills", State = "CA", Country = "USA" },
            new() { Code = "90211", City = "Beverly Hills", State = "CA", Country = "USA" },
            new() { Code = "90212", City = "Beverly Hills", State = "CA", Country = "USA" },
            new() { Code = "60601", City = "Chicago", State = "IL", Country = "USA" },
            new() { Code = "60602", City = "Chicago", State = "IL", Country = "USA" },
            new() { Code = "60603", City = "Chicago", State = "IL", Country = "USA" },
            new() { Code = "33101", City = "Miami", State = "FL", Country = "USA" },
            new() { Code = "33102", City = "Miami", State = "FL", Country = "USA" },
            new() { Code = "33103", City = "Miami", State = "FL", Country = "USA" },
            new() { Code = "78701", City = "Austin", State = "TX", Country = "USA" },
            new() { Code = "78702", City = "Austin", State = "TX", Country = "USA" },
            new() { Code = "78703", City = "Austin", State = "TX", Country = "USA" }
        };

        _addresses = new List<Address>
        {
            // New York 10001
            new() { Id = 1, StreetNumber = "100", Street = "Broadway", PostalCode = "10001", City = "New York", State = "NY", Country = "USA" },
            new() { Id = 2, StreetNumber = "200", Street = "Broadway", PostalCode = "10001", City = "New York", State = "NY", Country = "USA" },
            new() { Id = 3, StreetNumber = "150", Street = "5th Avenue", PostalCode = "10001", City = "New York", State = "NY", Country = "USA" },
            
            // Beverly Hills 90210
            new() { Id = 4, StreetNumber = "100", Street = "Rodeo Drive", PostalCode = "90210", City = "Beverly Hills", State = "CA", Country = "USA" },
            new() { Id = 5, StreetNumber = "200", Street = "Rodeo Drive", PostalCode = "90210", City = "Beverly Hills", State = "CA", Country = "USA" },
            new() { Id = 6, StreetNumber = "300", Street = "Wilshire Blvd", PostalCode = "90210", City = "Beverly Hills", State = "CA", Country = "USA" },
            
            // Chicago 60601
            new() { Id = 7, StreetNumber = "100", Street = "N State St", PostalCode = "60601", City = "Chicago", State = "IL", Country = "USA" },
            new() { Id = 8, StreetNumber = "200", Street = "N Michigan Ave", PostalCode = "60601", City = "Chicago", State = "IL", Country = "USA" },
            new() { Id = 9, StreetNumber = "300", Street = "W Loop", PostalCode = "60601", City = "Chicago", State = "IL", Country = "USA" },
            
            // Miami 33101
            new() { Id = 10, StreetNumber = "100", Street = "Ocean Drive", PostalCode = "33101", City = "Miami", State = "FL", Country = "USA" },
            new() { Id = 11, StreetNumber = "200", Street = "Collins Ave", PostalCode = "33101", City = "Miami", State = "FL", Country = "USA" },
            new() { Id = 12, StreetNumber = "300", Street = "Washington Ave", PostalCode = "33101", City = "Miami", State = "FL", Country = "USA" },
            
            // Austin 78701
            new() { Id = 13, StreetNumber = "100", Street = "Congress Ave", PostalCode = "78701", City = "Austin", State = "TX", Country = "USA" },
            new() { Id = 14, StreetNumber = "200", Street = "S Lamar Blvd", PostalCode = "78701", City = "Austin", State = "TX", Country = "USA" },
            new() { Id = 15, StreetNumber = "300", Street = "Barton Springs Rd", PostalCode = "78701", City = "Austin", State = "TX", Country = "USA" }
        };
    }

    public async Task<IEnumerable<PostalCode>> SearchPostalCodesAsync(string searchTerm)
    {
        await Task.Delay(100); // Simulate async operation
        
        if (string.IsNullOrWhiteSpace(searchTerm))
            return new List<PostalCode>();

        return _postalCodes
            .Where(pc => pc.Code.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase) || 
                        pc.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .Take(10)
            .ToList();
    }

    public async Task<IEnumerable<Address>> GetAddressesByPostalCodeAsync(string postalCode)
    {
        await Task.Delay(100); // Simulate async operation
        
        if (string.IsNullOrWhiteSpace(postalCode))
            return new List<Address>();

        return _addresses
            .Where(a => a.PostalCode.Equals(postalCode, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}