using System;

namespace ConsoleApp1
{
    public partial class Appointment
    {
        public bool ValidateAppointment()
        {
            if (string.IsNullOrWhiteSpace(PatientName))
                return false;

            if (string.IsNullOrWhiteSpace(DoctorName))
                return false;

            if (ConsultationFee <= 0)
                return false;

            return true;
        }
    }
}