namespace AT.UFTMS.WebAPI.Domain.Entities;
public class User 
    : Common.Entity
{
    #region Constructor
    
    public User(Guid id,
                string? username,
                string? fullName,
                string? passwordHash,
                Enums.Role role)
        : base(id)
    {
        SetUsername(username);
        SetFullName(fullName);
        SetPasswordHash(passwordHash);
        Role = role;
    } 

    #endregion

    #region Properties
    
    public string? Username { get; private set; }

    public string? FullName { get; private set; }

    public string? PasswordHash { get; private set; }

    public Enums.Role Role { get; private set; }

    #endregion

    #region Private: Method(s)
    
    private void SetUsername(string? username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new Exceptions.DomainException("Username is required.");

        Username = username;
    }

    private void SetFullName(string? fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new Exceptions.DomainException("Full name is required.");

        FullName = fullName;
    }

    private void SetPasswordHash(string? passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new Exceptions.DomainException("Password hash is required.");

        PasswordHash = passwordHash;
    } 

    #endregion
}