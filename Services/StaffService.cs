using ITEHAProject.Models;

namespace ITEHAProject.Services;

public class StaffService
{
    private List<StaffMember> _staff = new List<StaffMember>(); // creates a list of staff members

    public void Add(StaffMember staffMember) // adds a staff member to the list
    {
        _staff.Add(staffMember);
    }

    public List<StaffMember> GetAll() // returns all staff members from the list
    {
        return _staff;
    }

    public StaffMember? GetById(int id) // returns a staff member by their ID
    {
        return _staff.FirstOrDefault(s => s.StaffId == id);
    }

    public void Update(StaffMember member) // updates a staff member in the list
    {
        var existingMember = GetById(member.StaffId);
        if (existingMember != null)
        {
            existingMember.FullName = member.FullName;
            existingMember.Email = member.Email;
            existingMember.Position = member.Position;
            existingMember.Unit = member.Unit;
        }
    }

    public void Delete(int id) // deletes a staff member from the list
    {
        var member = GetById(id);
        if (member != null)
        {
            _staff.Remove(member);
        }
    }
}
