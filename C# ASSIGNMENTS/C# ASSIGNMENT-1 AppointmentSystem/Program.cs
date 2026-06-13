using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Appointment> appointmentList =
            new List<Appointment>()
            {
                new Appointment()
                {
                    AppointmentId = 301,
                    PatientName = "Rahul",
                    DoctorName = "Dr Meena",
                    Department = "Pediatrics",
                    AppointmentDate = DateTime.Now.AddDays(2),
                    Status = "Scheduled",
                    ConsultationFee = 550
                },
                        
                new Appointment()
                {
                    AppointmentId = 302,
                    PatientName = "Priya",
                    DoctorName = "Dr Karthik",
                    Department = "ENT",
                    AppointmentDate = DateTime.Now.AddDays(-3),
                    Status = "Completed",
                    ConsultationFee = 850
                },

                new Appointment()
                {
                    AppointmentId = 303,
                    PatientName = "Arun",
                    DoctorName = "Dr Nandhini",
                    Department = "Orthopedics",
                    AppointmentDate = DateTime.Now.AddDays(5),
                    Status = "Scheduled",
                    ConsultationFee = 700
                },

                new Appointment()
                {
                    AppointmentId = 304,
                    PatientName = "Sneha",
                    DoctorName = "Dr Vikram",
                    Department = "Gynecology",
                    AppointmentDate = DateTime.Now.AddDays(-1),
                    Status = "Completed",
                    ConsultationFee = 950
                },

                new Appointment()
                {
                    AppointmentId = 305,
                    PatientName = "Kavin",
                    DoctorName = "Dr Ramesh",
                    Department = "Dermatology",
                    AppointmentDate = DateTime.Now.AddDays(4),
                    Status = "Scheduled",
                    ConsultationFee = 600
                }
            };

            Console.WriteLine("All Appointments\n");

            foreach (var item in appointmentList)
            {
                Console.WriteLine(item.ShowAppointment());
            }

            Console.WriteLine("Scheduled Appointments\n");

            foreach (var item in appointmentList)
            {
                if (item.Status == "Scheduled")
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }

            Console.WriteLine("Completed Appointments\n");

            foreach (var item in appointmentList)
            {
                if (item.Status == "Completed")
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }

            Console.WriteLine("Appointments from Cardiology Department\n");

            foreach (var item in appointmentList)
            {
                if (item.Department == "Cardiology")
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }

            Console.WriteLine("Appointments with Consultation Fee Greater Than 500\n");

            foreach (var item in appointmentList)
            {
                if (item.ConsultationFee > 500)
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }

            Console.WriteLine("Appointments Sorted By Date\n");

            var sortedAppointments =
            appointmentList.OrderBy(a => a.AppointmentDate);

            foreach (var item in sortedAppointments)
            {
                Console.WriteLine(item.ShowAppointment());
            }

            Console.WriteLine("Search Appointment By Patient Name : Joel\n");

            string searchName = "Joel";

            foreach (var item in appointmentList)
            {
                if (item.PatientName.Contains(searchName))
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }

            Console.WriteLine("Appointments Grouped By Department\n");

            var departmentGroups =
            appointmentList.GroupBy(a => a.Department);

            foreach (var group in departmentGroups)
            {
                Console.WriteLine($"Department : {group.Key}");

                foreach (var item in group)
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }

            Console.WriteLine("Appointment Count By Status\n");

            var statusGroups =
            appointmentList.GroupBy(a => a.Status);

            foreach (var group in statusGroups)
            {
                Console.WriteLine($"{group.Key} : {group.Count()}");
            }

            decimal revenue = 0;

            foreach (var item in appointmentList)
            {
                if (item.Status == "Completed")
                {
                    revenue += item.ConsultationFee;
                }
            }

            Console.WriteLine(
            $"\nTotal Revenue From Completed Appointments : ₹{revenue}");

            decimal averageFee =
            appointmentList.Average(a => a.ConsultationFee);

            Console.WriteLine(
            $"\nAverage Consultation Fee : ₹{averageFee:F2}");

            Console.WriteLine("\nUpcoming Appointments\n");

            foreach (var item in appointmentList)
            {
                if (item.AppointmentDate > DateTime.Now)
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }

            Console.ReadKey();
        }
    }
}