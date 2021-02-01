import React, { useState, useEffect } from 'react';
import { Button, Form, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { useHistory } from "react-router-dom";
import { CustomField } from './CustomField';

export const CustomForm = ({ fields, vehicleType, setFields }) => {
    const history = useHistory();
    const [values, setValues] = useState({});
    const [error, setError] = useState({ validationErrors: [] });


    const [modal, setModal] = useState(false);

    const toggle = () => {
        setModal(!modal);
        history.push(`/get-${vehicleType}s`);
    }
    useEffect(() => {
        setError({ validationErrors: [] });
        setValues({});
    }, [fields]);

    const handleFieldChange = (fieldId, value) => {
        setValues({ ...values, [fieldId]: value });
    };

    const render = () => {                
        return fields.sort(function (a, b) { return a.propertySortOrder - b.propertySortOrder }).map(f => {            
            return (<CustomField fieldName={f.propertyName} validationName={f.propertyValidationTypeName} elementName={f.propertyElementName} formatName={f.propertyFormatName} key={f.propertyName} id={f.propertyName}  onChange={handleFieldChange}></CustomField>);
        });
    };
    const onSubmit = async (e) => {
        e.preventDefault();

        const filledFields = Object.values(values);
        if (filledFields.length !== fields.length) {
            setError({ validationErrors: ['*Please fill all fields'] });
        }
        else {
            setError({ validationErrors: [] });
            const response = await fetch(`${vehicleType}/Create`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(values)
            });
            if (response.status === 200) {
                setModal(true);
            }
            else {
                response.json().then(data => {
                    console.log(data);
                    if (data.errors) {
                        let newErrors = Object.values(data.errors);
                        setError({ validationErrors: newErrors });
                    }
                    else {
                        setError({ validationErrors: ['Something was wrong.'] });
                    }
                });
            }
        }
    }
    const renderError = () => {
        return (error.validationErrors.map((e, index) => <li key={index}> {e}</li>)
        )
    }
    return (
        <div>
            <Form onSubmit={onSubmit}>
                {render()}  
                {fields.length > 0 ? <Button>Create</Button> : ''}
                <ul>{renderError()}</ul>
            </Form>
            <Modal isOpen={modal} toggle={toggle}>
                <ModalHeader toggle={toggle}>Message</ModalHeader>
                <ModalBody>
                    Added
                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={toggle}>OK</Button>
                </ModalFooter>
            </Modal>
        </div>
    );


}
