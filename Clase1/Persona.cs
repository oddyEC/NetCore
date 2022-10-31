public class Persona {

    public string? Nombre {get;set;}

    private string? identificacion;

    public string? GetIdentificacion()
    {
        return identificacion;
    }

    public string GetIdentificacion(string? identificacion) => identificacion;

    public void SetIdentificacion(string value)
    {
        identificacion = value;
    }

    protected virtual string? RegistroUnico {get;set;}

    public virtual bool RegistrarIngreso(){
           return false;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}. Identificacion {GetIdentificacion(GetIdentificacion())}";
    }

}

public class Estudiante:Persona {

    public List<string> Cursos {get;set;}
 
    public override string ToString()
    {
        return $"Nombre: {Nombre}. Identificacion {GetIdentificacion(GetIdentificacion())}. Cursos: {string.Join(",",Cursos)}";
    }

    public Estudiante(){
        Cursos = new List<string>();
        this.RegistroUnico = "Estudiante";
    }
}

public class Profesor:Persona {

    public List<string> Materias {get;set;} = new List<string>();

    public override bool RegistrarIngreso(){
        return true;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}. Identificacion {GetIdentificacion(GetIdentificacion())}. Materias: {string.Join(",",Materias)}";
    }

    public Profesor(){ 
        this.RegistroUnico = "Profesor";
    }
}