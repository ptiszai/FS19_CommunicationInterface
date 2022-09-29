--
-- Communication Interface for FS19
-- @author:    	Tiszai Istvan (tiszaii@hotmail.com)
-- @history:	2022-09-30
--

local directory = g_currentModDirectory
local modName = g_currentModName


CommunicationInterfaceRegister = {}

-- if you want to add a specialization to an existing vehicleType you can use this function
-- function to register specializations to existing vehicleTypes
function CommunicationInterfaceRegister.registerSpecializationVehicle(vehicleType, specialization, specName)
    print("-----register specialization to vehicleType : ".. vehicleType.name)
    table.insert(vehicleType.specializationNames, specName)
    vehicleType.specializationsByName[specName] = specialization
    table.insert(vehicleType.specializations, specialization)
end

-- register specializations
g_specializationManager.addSpecialization('communicationInterface', 'communicationInterface', 'CommunicationInterface',  Utils.getFilename("CommunicationInterface.lua", g_currentModDirectory))
    
-- only needed if you want to add specialization to an existing vehicleType. Here sowingMachine
-- register exampleSpec to vehicleType sowingMachine
if  g_vehicleTypeManager.vehicleTypes.sowingMachine ~= nil then
    CommunicationInterfaceRegister.registerSpecializationVehicle(g_vehicleTypeManager.vehicleTypes.sowingMachine, CommunicationInterface, 'communicationinterface')
    CommunicationInterfaceRegister.registerSpecializationVehicle(g_vehicleTypeManager.vehicleTypes.tractor, CommunicationInterface, 'communicationinterface')
end