namespace InsuranceCompany.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
        public string Name { get; set; } // Providing a public setter

        
        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
}
