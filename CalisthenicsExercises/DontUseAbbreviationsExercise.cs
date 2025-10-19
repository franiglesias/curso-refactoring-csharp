// Regla de calistenia: No usar abreviaturas
// EJEMPLO DE VIOLACIÓN: Identificadores abreviados que oscurecen la intención

namespace CalisthenicsExercises
{
    // Traducción directa desde TypeScript preservando los mismos "code smells"
    public class Cfg
    {
        public string usr;
        public string pwd;
        public string srv;
        public string env; // 'dev' | 'prod' (no modelado como enum intencionalmente)

        public Cfg(string u, string p, string s, string e)
        {
            this.usr = u;
            this.pwd = p;
            this.srv = s;
            this.env = e;
        }

        public string connStr()
        {
            return $"{this.usr}:{this.pwd}@{this.srv}/{this.env}";
        }
    }

    /*
    Ejercicio (refactorizar hacia la regla):
    - Expandir nombres para transmitir la intención:
    - Aceptación: No quedan abreviaturas ambiguas; el código se lee como prosa.
    */
}
