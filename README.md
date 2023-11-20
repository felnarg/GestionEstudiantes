# GestionEstudiantes

se implementaron 3 tablas, cursos, estudiantes y estudiantes nocturnos
se creo la base de datos con fluent api y se agregaron las relaciones entre tablas, también los requerimientos de cada propiedad
se implementaron los servicios para cada una de las clases

Course> - getbyid      
          getall
          post
          update
          delete

Student> - getbyid      
           getall
           post
           update
           delete
           getbyage
           getdaily (horario del estudiante diurno)

NightStudent> - getbyid      
                getall
                post
                update
                delete
                getbyage
                getdaily (horario del estudiante diurno) 

se aplicó polimorfismo sobrescribiendo el metodo getdaily de las clases student y nightstudent
se implementaron las interfaces para cada servicio para exponer los metodos y usarlos en los controladores
y adicionalmente se hizo uso del patrón repository para el acceso a datos
se implementaron archivos de recursos y archivos de constantes para evitar código quemado
se implementaron validaciones para la clase cursos
se agruparon las inyecciones de dependencias y se inyectaron de forma simplificada en la clase program
          
