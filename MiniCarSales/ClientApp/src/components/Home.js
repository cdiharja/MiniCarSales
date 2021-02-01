import React, { useState, useEffect } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { CustomForm } from './CustomForm';

export const Home = () => {

    const defaultDropdownValue = 'Select action';
    const [metadata, setMetadata] = useState(null);
    const [dropdownOpen, setDropdownOpen] = useState(false);
    const [currentDropdownValue, setCurrentDropdownValue] = useState(defaultDropdownValue);
    const [fields, setFields] = useState([]);

    const toggle = () => setDropdownOpen(prevState => !prevState);
    const populateMetaData = async () => {
        const response = await fetch('home');
        const data = await response.json();
        setMetadata(data);
    }

    useEffect(() => {
        populateMetaData()
    }, []);

    const onDropdownClick = (vehicleTypeName) => {

        setCurrentDropdownValue(vehicleTypeName);
        if (vehicleTypeName === defaultDropdownValue) {
            console.log("clear");
        }
        loadFields(vehicleTypeName);
        //console.log(vehicleTypeName);
    }

    const loadFields = (vehicleTypeName) => {
        const foundVehicle = metadata.vehiclesMetaData.find(v => v.vehicleTypeName === vehicleTypeName);
        if (foundVehicle !== undefined) {
            setFields(foundVehicle.propertiesData);
        }
        else setFields([]);
       // console.log(foundVehicle);
       // console.log(Object.assign({}, ...metadata.vehiclesMetaData));
      //  console.log(Object.values(metadata.vehiclesMetaData));
    }

    const renderDropdownItem = () => {
        const vehiclesMetaData =metadata.vehiclesMetaData;
        return vehiclesMetaData.map(v => {
            return (<DropdownItem onClick={() => onDropdownClick(v.vehicleTypeName)} key={v.vehicleTypeName}>Create {v.vehicleTypeName}</DropdownItem>)
        });
    }

    const render = () => {

        if (metadata != null) {            
            return (
                <Dropdown isOpen={dropdownOpen} toggle={toggle}>
                    <DropdownToggle caret>
                        {currentDropdownValue}
                    </DropdownToggle>
                    <DropdownMenu>
                        {currentDropdownValue !== defaultDropdownValue ? <DropdownItem onClick={() => onDropdownClick(defaultDropdownValue)} key={defaultDropdownValue}>{defaultDropdownValue}</DropdownItem>:''}
                        {renderDropdownItem()}
                    </DropdownMenu>
                </Dropdown>
            );
        }           
    }

    return (
            <div>
            <div> {render()}</div>
            <div><CustomForm fields={fields} setFields={setFields} vehicleType={currentDropdownValue}></CustomForm></div>
            </div>
    );
   

}
