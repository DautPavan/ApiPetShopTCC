
#Daut Pavan 25/08/2021
# ApiPetShopTCC

--Migrations comands--- 
--startup-project [
					Comando que aponta para qual arquivo é o start da aplicação
					aplicação necessita ter o Microsoft.EntityFrameworkCore.Design de dependencia
				  ]


--project [
			Comando aponta para a aplicação que tenha o geralmente de DbContext
			Aplicação necessata ter o Microsoft.EntityFrameworkCore.Tools
		  ]

dotnet ef --startup-project PetShopAPI/PetShopAPI.csproj --project Dados/Dados.csproj [commands Ef]
