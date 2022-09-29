--
-- Communication Interface for FS19
-- @author:    	Tiszai Istvan (tiszaii@hotmail.com)
-- @history:	2022-09-30
--

CommunicationInterface = {}
CommunicationInterface.number = 0
CommunicationInterface.text = "something"
CommunicationInterface.modDirectory = g_currentModDirectory
CommunicationInterface.drive = "r:\\" -- ram drive

---
function CommunicationInterface.prerequisitesPresent(specializations)
	return SpecializationUtil.hasSpecialization(CommunicationInterface, specializations)
end

---
function CommunicationInterface.registerEventListeners(vehicleType)  
    print("INFO:CommunicationInterface:registerEventListeners")
    for _,n in pairs( {"onLoad", "onPostLoad" }) do
        SpecializationUtil.registerEventListener(vehicleType, n, CommunicationInterface)
    end
    table.insert(vehicleType.eventListeners.onRegisterActionEvents, CommunicationInterface)
end

---
function  CommunicationInterface.registerOverwrittenFunctions(vehicleType)
    print("INFO:CommunicationInterface.registerOverwrittenFunctions");    
    -- Only needed for action event for player
    Player.registerActionEvents = Utils.appendedFunction(Player.registerActionEvents, CommunicationInterface.registerActionEventsPlayer); 
    Player.update = Utils.appendedFunction(Player.update, CommunicationInterface.update);       
end

--- only needed for action event for vehicle
function CommunicationInterface:onRegisterActionEvents(isSelected, isOnActiveVehicle)
    print("INFO:CommunicationInterface:onRegisterActionEvents") 
    -- this function is called onLoad of a vehicle and when the state of the vehicle changes
    -- when the vehicle is selected then isSelected is true
    -- when the vehicle is attached to a vehicle that is active isOnActiveVehicle is true
	if self.isClient and self:getIsActiveForInput(true, true) then
		if self.communicationActionEvents == nil then 
			self.communicationActionEvents = {}
		end 
        if self:getIsActiveForInput(true, true) then
            for _,actionName in pairs({ "READ2_XML", 
                }) do
                local _, eventName = self:addActionEvent(self.communicationActionEvents, InputAction[actionName], self, CommunicationInterface.onActionCallback, false, true, false, true, nil);
                if g_inputBinding ~= nil and g_inputBinding.events ~= nil and g_inputBinding.events[eventName] ~= nil then                                    
                    g_inputBinding.events[eventName].displayPriority = 1                     
                end
            end
        end
	end
end

--- only needed for action event for player
function CommunicationInterface:registerActionEventsPlayer()
    print("CommunicationInterface:registerActionEventsPlayer")
	if self.isClient then     
        for _,actionName in pairs({ "READ1_XML",                                 
        }) do        
            local _, actionEventId1 = g_inputBinding:registerActionEvent(InputAction[actionName], self,  CommunicationInterface.onActionKeyPressed , false, true, false, true) 
            if g_inputBinding ~= nil and g_inputBinding.events ~= nil and g_inputBinding.events[eventName] ~= nil then                                    
                g_inputBinding.events[eventName].displayPriority = 1                     
            end        
        end
	end
    --    DebugUtil.printTableRecursively(g_inputBinding,"-",0,1)
end

---
function CommunicationInterface:onActionKeyPressed(actionName, keyStatus, arg4, arg5, arg6)   
    --print(actionName)
    --print(keyStatus) --1.00 pressed 0.000 not pressed, maybe any value for analog inputs
    --print(arg4) --nil maybe callbackStatus
    --print(arg5) --bool unknown
    --print(arg6) --bool unknown
    --local spec = self.spec_helpercontrol  
    if keyStatus > 0 then 
        if actionName == "READ1_XML" then
            if CommunicationInterface:reading_xml() then
                print("INFO:CommunicationInterface:onActionKeyPressed , READ1_XML, GOOD") 
            else
                print("INFO:CommunicationInterface:onActionKeyPressed , READ1_XML, BAD")
           end      
        end
    end
end

--- if vehicle is selected.
function CommunicationInterface:onActionCallback(actionName, keyStatus, arg4, arg5, arg6)
   -- print("INFO:CommunicationInterface:onActionCallback for vehicles")
    if keyStatus > 0 then    
        if actionName == "READ2_XML" then
            if self:reading_xml() then
                print("INFO:CommunicationInterface:onActionCallback , READ2_XML, GOOD") 
            else
                print("INFO:CommunicationInterface:onActionCallback , READ2_XML, BAD")
            end
        end
    end
end

---
function CommunicationInterface:onLoad(savegame)
    print("INFO:CommunicationInterface:onLoad")       
    self.create_xml = CommunicationInterface.create_xml
    local spec = self.spec_communicationinterface
    spec.number = 0
    spec.dtMs = 0
end

---
function CommunicationInterface:onPostLoad(savegame)
    local spec = self.spec_communicationinterface
    g_currentMission:showBlinkingWarning(string.format('Number: %d ',spec.number), 1000)
end

---
function CommunicationInterface:update(dt)
--print("INFO:CommunicationInterface:update")
    if self.time >= 2000 then            
        CommunicationInterface.number = CommunicationInterface.number + 1
        g_currentMission:showBlinkingWarning(string.format('Text: %s,Number: %d ',CommunicationInterface.text, CommunicationInterface.number), 1000)
        CommunicationInterface:writting_xml()
        self.time = 0
    end
end

---
function CommunicationInterface:writting_xml()
    local spec = self.spec_communicationinterface
    local _xmlFile = createXMLFile("FS19ToApp", CommunicationInterface.drive .. "FS19ToApp.xml", "FS19ToApp") 
    if _xmlFile ~= nil then 
        setXMLString(_xmlFile, "FS19ToApp#text", CommunicationInterface.text)   
        setXMLInt(_xmlFile, "FS19ToApp#number", CommunicationInterface.number)                       
        saveXMLFile(_xmlFile) 
        delete(_xmlFile) 
    end
end

---
function CommunicationInterface:reading_xml()
    local spec = self.spec_communicationinterface     
    local file = Utils.getFilename("AppToFS19.xml" , CommunicationInterface.drive);
    if file == nil then 
        return false
    end
    if fileExists(file) == false then 
        return false
    end
    local xmlFile = loadXMLFile('CommunicationInterface', file, "AppToFS19");
    if xmlFile == nil then
        return false
    end
    local key  = string.format( "AppToFS19#text")
    if not hasXMLProperty(xmlFile, key) then
        return false
    end
    CommunicationInterface.text = getXMLString(xmlFile, key) 
    key  = string.format( "AppToFS19#number")
    if not hasXMLProperty(xmlFile, key) then
        return false
    end
    CommunicationInterface.number = getXMLInt(xmlFile, key) 
    return true
end