class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public string Street
    {
        get { return _street; }
        set { _street = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public string StateOrProvince
    {
        get { return _stateOrProvince; }
        set { _stateOrProvince = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    public bool IsInUSA()
    {
        return _country.Trim().ToUpper() == "USA" || _country.Trim().ToUpper() == "UNITED STATES";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
