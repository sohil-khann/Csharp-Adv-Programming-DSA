/*
 2. Role-Based Access Control (RBAC)
 Use Case: Assign and verify user roles and permissions.
 OOP Concepts:
 - Interface: IRole (Defines role-based permissions)
 - Encapsulation: User-to-Role mappings hidden inside the AuthSystem.
 - Abstraction & Polymorphism: Different roles (Admin, Guest) implement different behaviors.
*/

using System;
using System.Collections.Generic;

namespace HashMapManagement
{
    // Interface for different user roles
    public interface IRole
    {
        string RoleName { get; }
        bool CanAccessAdminPanel();
    }

    // Admin role implementation
    public class AdminRole : IRole
    {
        public string RoleName => "Administrator";
        public bool CanAccessAdminPanel() => true;
    }

    // Guest role implementation
    public class UserRole : IRole
    {
        public string RoleName => "Standard User";
        public bool CanAccessAdminPanel() => false;
    }

    // Authentication System class
    public class AuthSystem
    {
        // Maps Username -> Role (HashMap)
        private Dictionary<string, IRole> _userRoles = new Dictionary<string, IRole>();

        public void AssignRole(string username, IRole role)
        {
            _userRoles[username] = role; // Adds or updates role
            Console.WriteLine($"Assigned {role.RoleName} role to user: {username}");
        }

        public void VerifyAccess(string username)
        {
            if (_userRoles.ContainsKey(username))
            {
                IRole role = _userRoles[username];
                Console.WriteLine($"User: {username} | Role: {role.RoleName}");
                if (role.CanAccessAdminPanel())
                {
                    Console.WriteLine("Access Granted to Admin Panel.");
                }
                else
                {
                    Console.WriteLine("Access Denied: Standard users cannot enter Admin Panel.");
                }
            }
            else
            {
                Console.WriteLine($"User '{username}' not found in the system.");
            }
        }
    }

    public class RBACDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Use Case 2: Role-Based Access Control (RBAC) ---");
            AuthSystem auth = new AuthSystem();

            auth.AssignRole("sohil_admin", new AdminRole());
            auth.AssignRole("Raj", new UserRole());

            Console.WriteLine("\nVerifying access for users:");
            auth.VerifyAccess("sohil_admin");
            Console.WriteLine("-------------------");
            auth.VerifyAccess("Raj");
            Console.WriteLine("-------------------");
            auth.VerifyAccess("unknown_user");
            Console.WriteLine();
        }
    }
}
