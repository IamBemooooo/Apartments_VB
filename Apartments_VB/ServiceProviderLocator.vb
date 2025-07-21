Public NotInheritable Class ServiceProviderLocator
    Public Shared Property UserService As IUserService
    Public Shared Property ApartmentService As IApartmentService
    Public Shared Property ApartmentTypeService As IApartmentTypeService
    Public Shared Property ApartmentResidentService As IApartmentResidentService
    Public Shared Property ResidentService As IResidentService
    Public Shared Property MaintenanceRequestService As IMaintenanceRequestService
End Class
