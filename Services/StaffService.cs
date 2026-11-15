using ITEHAProject.Models;

namespace ITEHAProject.Services;

public class StaffService
{
    private readonly List<StaffMember> _staff = new();
    private readonly Lock _staffLock = new();

    public void Add(StaffMember staffMember)
    {
        lock (_staffLock)
        {
            _staff.Add(staffMember);
        }
    }

    public List<StaffMember> GetAll()
    {
        lock (_staffLock)
        {
            return new List<StaffMember>(_staff);
        }
    }

    public StaffMember? GetById(int id)
    {
        lock (_staffLock)
        {
            var index = FindIndexById(id);
            return index >= 0 ? _staff[index] : null;
        }
    }

    public void Update(StaffMember member)
    {
        lock (_staffLock)
        {
            var index = FindIndexById(member.StaffId);
            if (index >= 0)
            {
                var existingMember = _staff[index];
                existingMember.FullName = member.FullName;
                existingMember.Email = member.Email;
                existingMember.Position = member.Position;
                existingMember.Unit = member.Unit;
            }
        }
    }

    public void Delete(int id)
    {
        lock (_staffLock)
        {
            var index = FindIndexById(id);
            if (index >= 0)
            {
                _staff.RemoveAt(index);
            }
        }
    }

    private int FindIndexById(int id)
    {
        for (var index = 0; index < _staff.Count; index++)
        {
            if (_staff[index].StaffId == id)
            {
                return index;
            }
        }

        return -1;
    }
}
