using System;

namespace ConsoleApp1
{
    public partial class Appointment
    {
        public string ShowAppointment()
        {
            return
            $"Id : {AppointmentId}\n" +
            $"Patient : {PatientName}\n" +
            $"Doctor : {DoctorName}\n" +
            $"Department : {Department}\n" +
            $"Date : {AppointmentDate:dd-MM-yyyy}\n" +
            $"Status : {Status}\n" +
            $"Fee : ₹{ConsultationFee}\n";
        }
    }
}