// Code smell: Refused Bequest [Herencia rechazada]. Una subclase hereda de un tipo base pero sobrescribe/ignora
// partes del contrato, lo que indica una jerarquía equivocada o una abstracción faltante.

// Ejercicio: Añade un método de ciclo de vida "pause" requerido por todos los controladores y vuelve
// obligatorios start/stop.

// ReadOnlyController forzará excepciones incómodas o implementaciones no-op,
// mostrando el coste de una herencia mal planteada.

using System;

namespace CodeSmells.OopAbusers
{
    public class BaseController
    {
        public virtual void Start()
        {
            Console.WriteLine("starting");
        }

        public virtual void Stop()
        {
            Console.WriteLine("stopping");
        }

        public virtual void Reset()
        {
            Console.WriteLine("resetting");
        }
    }

    public class ReadOnlyController : BaseController
    {
        public override void Start()
        {
            // no-op
        }

        public override void Stop()
        {
            // no-op
        }

        public override void Reset()
        {
            throw new NotSupportedException("operation not supported");
        }
    }

    public static class RefusedBequestDemo
    {
        public static void DemoRefusedBequest(bool readOnly)
        {
            BaseController controller = readOnly ? new ReadOnlyController() : new BaseController();
            controller.Start();
            controller.Stop();
        }
    }
}
