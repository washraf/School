﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School.Management.Presentation.Console.StudentAffairsService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StudentAffairsService.IStudentAffairsService")]
    public interface IStudentAffairsService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceBase/Nothing")]
        void Nothing();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceBase/Nothing")]
        System.Threading.Tasks.Task NothingAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/CreateStudent", ReplyAction="http://tempuri.org/IStudentAffairsService/CreateStudentResponse")]
        bool CreateStudent(School.Management.Domain.Entities.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/CreateStudent", ReplyAction="http://tempuri.org/IStudentAffairsService/CreateStudentResponse")]
        System.Threading.Tasks.Task<bool> CreateStudentAsync(School.Management.Domain.Entities.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/UpdateStudent", ReplyAction="http://tempuri.org/IStudentAffairsService/UpdateStudentResponse")]
        bool UpdateStudent(School.Management.Domain.Entities.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/UpdateStudent", ReplyAction="http://tempuri.org/IStudentAffairsService/UpdateStudentResponse")]
        System.Threading.Tasks.Task<bool> UpdateStudentAsync(School.Management.Domain.Entities.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/RemoveStudent", ReplyAction="http://tempuri.org/IStudentAffairsService/RemoveStudentResponse")]
        bool RemoveStudent(School.Management.Domain.Entities.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/RemoveStudent", ReplyAction="http://tempuri.org/IStudentAffairsService/RemoveStudentResponse")]
        System.Threading.Tasks.Task<bool> RemoveStudentAsync(School.Management.Domain.Entities.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/GetStudentsByName", ReplyAction="http://tempuri.org/IStudentAffairsService/GetStudentsByNameResponse")]
        School.Management.Domain.Entities.Student[] GetStudentsByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/GetStudentsByName", ReplyAction="http://tempuri.org/IStudentAffairsService/GetStudentsByNameResponse")]
        System.Threading.Tasks.Task<School.Management.Domain.Entities.Student[]> GetStudentsByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/GetStudentById", ReplyAction="http://tempuri.org/IStudentAffairsService/GetStudentByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action="http://tempuri.org/IStudentAffairsService/GetStudentByIdExceptionFault", Name="Exception", Namespace="http://schemas.datacontract.org/2004/07/System")]
        School.Management.Domain.Entities.Student GetStudentById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/GetStudentById", ReplyAction="http://tempuri.org/IStudentAffairsService/GetStudentByIdResponse")]
        System.Threading.Tasks.Task<School.Management.Domain.Entities.Student> GetStudentByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/RegisterToCourse", ReplyAction="http://tempuri.org/IStudentAffairsService/RegisterToCourseResponse")]
        bool RegisterToCourse(int studentId, int courseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentAffairsService/RegisterToCourse", ReplyAction="http://tempuri.org/IStudentAffairsService/RegisterToCourseResponse")]
        System.Threading.Tasks.Task<bool> RegisterToCourseAsync(int studentId, int courseId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStudentAffairsServiceChannel : School.Management.Presentation.Console.StudentAffairsService.IStudentAffairsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StudentAffairsServiceClient : System.ServiceModel.ClientBase<School.Management.Presentation.Console.StudentAffairsService.IStudentAffairsService>, School.Management.Presentation.Console.StudentAffairsService.IStudentAffairsService {
        
        public StudentAffairsServiceClient() {
        }
        
        public StudentAffairsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StudentAffairsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StudentAffairsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StudentAffairsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Nothing() {
            base.Channel.Nothing();
        }
        
        public System.Threading.Tasks.Task NothingAsync() {
            return base.Channel.NothingAsync();
        }
        
        public bool CreateStudent(School.Management.Domain.Entities.Student student) {
            return base.Channel.CreateStudent(student);
        }
        
        public System.Threading.Tasks.Task<bool> CreateStudentAsync(School.Management.Domain.Entities.Student student) {
            return base.Channel.CreateStudentAsync(student);
        }
        
        public bool UpdateStudent(School.Management.Domain.Entities.Student student) {
            return base.Channel.UpdateStudent(student);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateStudentAsync(School.Management.Domain.Entities.Student student) {
            return base.Channel.UpdateStudentAsync(student);
        }
        
        public bool RemoveStudent(School.Management.Domain.Entities.Student student) {
            return base.Channel.RemoveStudent(student);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveStudentAsync(School.Management.Domain.Entities.Student student) {
            return base.Channel.RemoveStudentAsync(student);
        }
        
        public School.Management.Domain.Entities.Student[] GetStudentsByName(string name) {
            return base.Channel.GetStudentsByName(name);
        }
        
        public System.Threading.Tasks.Task<School.Management.Domain.Entities.Student[]> GetStudentsByNameAsync(string name) {
            return base.Channel.GetStudentsByNameAsync(name);
        }
        
        public School.Management.Domain.Entities.Student GetStudentById(int id) {
            return base.Channel.GetStudentById(id);
        }
        
        public System.Threading.Tasks.Task<School.Management.Domain.Entities.Student> GetStudentByIdAsync(int id) {
            return base.Channel.GetStudentByIdAsync(id);
        }
        
        public bool RegisterToCourse(int studentId, int courseId) {
            return base.Channel.RegisterToCourse(studentId, courseId);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterToCourseAsync(int studentId, int courseId) {
            return base.Channel.RegisterToCourseAsync(studentId, courseId);
        }
    }
}
