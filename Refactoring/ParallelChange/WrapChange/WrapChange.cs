// Técnica de refactorización: Cambio en Paralelo mediante Wrap
// Propósito: Practicar el cambio de la interfaz de una dependencia externa/legada introduciendo un wrapper
// que soporte tanto las APIs vieja como nueva para poder migrar los puntos de llamada gradualmente.
//
// Escenario: Tenemos una función legada para enviar correos utilizada en todo el código. Queremos añadir
// un trackingId obligatorio y soporte de plantillas, pero no podemos actualizar todas las llamadas a la vez.
// Practicaremos creando un wrapper que mantenga la firma antigua funcionando mientras introducimos la nueva.

// API legada (supón que viene de una librería de terceros que no podemos cambiar rápido):
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

/*
Ejercicio: Cambio en Paralelo usando WRAP
Objetivo: Introducir una API de email más rica sin romper los puntos de llamada existentes.

Forma deseada de la nueva API (objetivo):
  interface EmailMessage { to: string; template: 'welcome' | 'password-reset' | 'custom'; data?: Record<string, unknown>; trackingId: string }
  class Mailer { send(msg: EmailMessage): void }

Pasos (haz commit entre pasos):
1) Crea un nuevo wrapper Mailer que en su constructor reciba una dependencia función para enviar el correo realmente.
   - Debe poder llamar a la función legada internamente para enrutar gradualmente.
   - Mantén el wrapper sin usar al principio para asegurar verde.
2) Introduce una sobrecarga o un método separado en Mailer que acepte AMBOS:
   - la nueva forma (EmailMessage) y
   - un método de compatibilidad sendLegacy(to, subject, body) que reenvíe a SendEmailLegacy.
   Documenta que sendLegacy es temporal.
3) Migra un punto de llamada (NotifyWelcome) para usar el wrapper con el método legado primero (sin cambio de comportamiento).
4) Añade soporte de plantillas en Mailer.Send(msg) mapeando plantillas a subject/body e incluyendo trackingId en el cuerpo.
   - Mantén el reenvío de sendLegacy intacto.
5) Migra NotifyWelcome para usar completamente la nueva API (EmailMessage) dejando NotifyPasswordReset en legado.
6) Finalmente, migra el resto de puntos de llamada y elimina sendLegacy del wrapper.

Criterios de aceptación:
- Mientras la migración está en curso, tanto los llamadores viejos como los nuevos funcionan.
- No hay cambio de comportamiento en tiempo de ejecución hasta que el paso 5 cambie explícitamente el formato del email.
- El wrapper aísla el cambio y sirve como la costura entre las APIs vieja y nueva.
*/
