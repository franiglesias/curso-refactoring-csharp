public static void SendEmailLegacy(string to, string subject, string body)
{
    // efecto secundario simulado (no-op aquí)
    _ = to;
    _ = subject;
    _ = body;
}

// Uso actual disperso por el código (aquí simulamos dos puntos de llamada):
public static void NotifyWelcome(string userEmail)
{
    SendEmailLegacy(userEmail, "Welcome!", "Thanks for joining our app.");
}

public static void NotifyPasswordReset(string userEmail)
{
    SendEmailLegacy(userEmail, "Reset your password", "Click the link to reset...");
}

