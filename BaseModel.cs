using System;

namespace GenericApi
{
    public class BaseModel
    {
        public Guid Id { get; set; } 
        public bool Completed {get; set;}       
    }
}