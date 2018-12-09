import React from 'react';
import { Col, Grid, Row } from 'react-bootstrap';	

export default props => (
  <Grid fluid>
    <Row>
      <Col>
        {props.children}
      </Col>
    </Row>
  </Grid>
);
