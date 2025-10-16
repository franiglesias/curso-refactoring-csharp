// Translated from CalisthenicsExamples/no-primitives.ts
// Keeps a value object Email instead of primitive string for the field
using System;

namespace CalisthenicsExamples
{
    public class User
    {
        private string name;
        private Email email;

        public User(string name, Email email)
        {
            this.name = name;
            this.email = email;
        }

        public void ChangeEmail(string newEmail)
        {
            this.email = new Email(newEmail);
        }
    }

    public class Email
    {
        private string value;

        public Email(string email)
        {
            if (email == null || !email.Contains("@"))
            {
                throw new ArgumentException("Invalid email");
            }
            this.value = email;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
