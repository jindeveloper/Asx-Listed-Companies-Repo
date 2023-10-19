import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Table, Container, Button, Pagination, Form, FormControl } from 'react-bootstrap';

function AsxCompany() {

    const [searchText, setSearchText] = useState('');
    const [data, setData] = useState([]);
    const apiUrl = `http://localhost:53857/api/AsxListedCompanies/GetCompanies?asxCode=${searchText}`;

    const handleSearch = (event) => setSearchText(event.target.value);

    const onClear = (event) => {

        setSearchText('');
        setData([]);

    }
    const onClick = (event) => {
        
        if(searchText !== ""){
            fetch(apiUrl)
            .then((response) => response.json())
            .then((result) => {
                console.log(result);
                setData(result);
            })
            .catch((error) => {
                console.error('Error fetching data: ', error);
            });
        }else{
            alert("You need to fillup the textbox before clicking the search button");
        }
       
    }

    return (
        <Container>
            <h1>Listed Companies</h1>
            <Form>
                <Form.Group controlId="searchForm">
                    <FormControl
                        type="text"
                        placeholder="Search..."
                        value={searchText}
                        onChange={handleSearch}
                    />
                    <br/>
                    <Button variant="outline-dark" onClick={onClick}>Submit</Button>
                   
                </Form.Group>
            </Form>
            {data.length > 0 ? (
                <div>
                    <h2 className="mt-4">Search Result</h2>
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>Company Name</th>
                                <th>AsxCode</th>
                            </tr>
                        </thead>
                        <tbody>
                            {data.map((item, index) => (
                                <tr key={index}>
                                    <td>{item.companyName}</td>
                                    <td>{item.asxCode}</td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                    <Button variant="outline-dark" onClick={onClear}>Clear</Button>
                </div>
            ) : (
                <p>No data available. Please enter a search term and click Submit.</p>
            )}
        </Container>
    );
}

export default AsxCompany;
