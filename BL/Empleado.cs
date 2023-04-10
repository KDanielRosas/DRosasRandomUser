using DL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DrosasEmpleadoCrudContext context = new())
                {
                    var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = item.IdEmpleado;
                            empleado.Nombre = item.Nombre;
                            empleado.ApellidoPaterno = item.ApellidoPaterno;
                            empleado.ApellidoMaterno = item.ApellidoMaterno;
                            empleado.Status = item.Status.Value;

                            result.Objects.Add(empleado); 
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//GetAll

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DrosasEmpleadoCrudContext context = new())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}'," +
                        $"'{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}', {empleado.Status}");

                    if (query > 1)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//Add

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DrosasEmpleadoCrudContext context = new())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate {empleado.IdEmpleado}," +
                        $"'{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}', {empleado.Status}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//Update
         
        public static ML.Result GetById(int idEmpleado)
        {
            ML.Result result = new();

            try
            {
                using (DrosasEmpleadoCrudContext context = new())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetById {idEmpleado}").AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Empleado empleado = new();
                        empleado.IdEmpleado = idEmpleado;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.Status = query.Status.Value;

                        result.Object = empleado;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//GetById

        public static ML.Result Delete(int idEmpleado)
        {
            ML.Result result = new();

            try
            {
                using (DrosasEmpleadoCrudContext context = new())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {idEmpleado}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                throw;
            }
            return result;
        }//Delete

        public static ML.Result ChangeStatus(int idEmpleado, bool status)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DrosasEmpleadoCrudContext context = new())
                {
                    int query = context.Database.ExecuteSqlRaw($"ChangeStatus {idEmpleado}, {status}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//ChangeStatus
    }
}