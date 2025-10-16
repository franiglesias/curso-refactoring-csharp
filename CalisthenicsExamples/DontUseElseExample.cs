// Translated from CalisthenicsExamples/dont-use-else.ts
// Preserves simple branching and factory example
using System;

namespace CalisthenicsExamples
{
    public static class UserCategorizer
    {
        public static string CategorizeUser(int age)
        {
            if (age < 13)
            {
                return "child";
            }

            if (age < 18)
            {
                return "teenager";
            }

            return "adult";
        }
    }

    public abstract class User { }
    public class ChildUser : User { }
    public class TeenagerUser : User { }
    public class AdultUser : User { }

    public class UserFactory
    {
        public User Create(int age)
        {
            if (age < 13)
            {
                return new ChildUser();
            }

            if (age < 18)
            {
                return new TeenagerUser();
            }

            return new AdultUser();
        }
    }
}
