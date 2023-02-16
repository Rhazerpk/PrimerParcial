using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class LibrosBLL{

    private Contexto _contexto;

    public LibrosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int LibroId)
    {
        return _contexto.libros.Any(o => o.LibroId == LibroId);

    }

    private bool Insertar(Libros libros)
    {
        _contexto.libros.Add(libros);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Libros libros)
    {
        _contexto.Entry(libros).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;

    }

    public bool Guardar(Libros libros)
    {
        if(!Existe(libros.LibroId))
            return this.Insertar(libros);
        else
            return this.Modificar(libros);
    }

    public bool Eliminar(Libros libros)
    {
        _contexto.Entry(libros).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Libros? Buscar(int LibroId)
    {
        return _contexto.libros
        .Where(o => o.LibroId == LibroId)
        .AsNoTracking()
        .SingleOrDefault();
    }

    public List<Libros> GetList(Expression<Func<Libros, bool>> Criterio)
    {
        return _contexto.libros
        .AsNoTracking()
        .Where(Criterio)
        .ToList();
    }

}