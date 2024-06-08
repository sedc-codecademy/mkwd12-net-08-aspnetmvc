namespace Class03_Models.Models.DtoModels
{
    public class StudentNameDto
    {
        //
        //public string StudentFullName { get; set; }
        //Better way of naming the property since we already have Student ibn our class
        //we will exacly know that FullName in this class will reffer to the student
        public string FullName { get; set; }
    }
}
