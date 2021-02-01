import React, { useState } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem, FormGroup, Input, Label } from 'reactstrap';

export const CustomField = ({ fieldName, elementName, validationName, formatName, onChange, id }) => {

    const [value, setValue] = useState('');
    const [dropdownOpen, setDropdownOpen] = useState(false);

    const toggle = () => setDropdownOpen(prevState => !prevState);

    const onTextboxChange = (e) => { 
        
        setValue(e.target.value);
        onChange(id, e.target.value);
    }
    const onDropdownClick = (val) => {
        onChange(id, val);
        setValue(val);
    }
    const loadDropDownValue = (validationName) => {
        
        const options = validationName.split(',');
        //TODO:get values from API
        return (
            options.map(opt => <DropdownItem key={opt} onClick={() => onDropdownClick(opt)} >{opt}</DropdownItem>)
            
        )
    }
    const getInputType = () => {
        switch (formatName) {
            case "string":
                return "text";
            case "int":
                return "number";
        }
        return "text";

    }
    const render = () => {
        switch (elementName) {
            case "textbox":
                return (
                    <FormGroup>
                        <Label for={fieldName}>{fieldName}:</Label>
                        <Input type={getInputType()} name={fieldName} value={value} onChange={onTextboxChange} />
                    </FormGroup>
                );
            case "dropdown":
                return (
                    <FormGroup>
                        <Label for={fieldName}>{fieldName}:</Label>
                        <Dropdown isOpen={dropdownOpen} toggle={toggle} className="dropdown-primary">
                            <DropdownToggle caret>
                                {value}
                            </DropdownToggle>
                            <DropdownMenu>
                                {loadDropDownValue(validationName)}
                            </DropdownMenu>
                        </Dropdown>
                    </FormGroup>
                );
            default:
            // code block
        }

        return (
            <p></p>
        )
    }

    return (
            <div>
             {render()}
            </div>
    );
   

}
