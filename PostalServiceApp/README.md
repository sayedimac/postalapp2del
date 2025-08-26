# Postal Service Lookup Application

A web-based MVP for postal service lookup built with ASP.NET Core 8.0.

## Features

- **Postal Code Search**: Users can type postal codes or city names to get suggestions
- **Auto-complete Dropdown**: Dynamic dropdown with postal code suggestions as you type
- **Address Enumeration**: View all addresses within a selected postal code area
- **Responsive Design**: Clean, modern UI built with Bootstrap 5

## How to Use

1. **Search**: Start typing in the "Search Postal Code" field
   - Enter a postal code (e.g., 10001, 90210, 60601)
   - Or enter a city name (e.g., New York, Beverly Hills, Chicago)

2. **Select**: Click on one of the suggested postal codes from the dropdown

3. **View Addresses**: The application will display all addresses within that postal code area

## Sample Data

The application includes sample data for demonstration:

- **New York** (10001, 10002, 10003)
- **Beverly Hills** (90210, 90211, 90212)
- **Chicago** (60601, 60602, 60603)
- **Miami** (33101, 33102, 33103)
- **Austin** (78701, 78702, 78703)

## Running the Application

1. Navigate to the PostalServiceApp directory
2. Run the following commands:

```bash
dotnet build
dotnet run
```

3. Open your browser and navigate to `http://localhost:5000`

## API Endpoints

- `GET /api/postal/search?q={searchTerm}` - Search for postal codes
- `GET /api/postal/{postalCode}/addresses` - Get addresses for a postal code

## Technology Stack

- **Backend**: ASP.NET Core 8.0
- **Frontend**: HTML, CSS, JavaScript, Bootstrap 5
- **Architecture**: MVC with API controllers
- **Data**: In-memory mock service (easily replaceable with real data source)