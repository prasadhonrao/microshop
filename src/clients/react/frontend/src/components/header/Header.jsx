import { LinkContainer } from 'react-router-bootstrap';

import { Navbar, Nav, Container } from 'react-bootstrap';
import { FaShoppingCart, FaUser } from 'react-icons/fa';
import logo from '../../assets/logo.png';

const Header = () => {
  return (
    <header>
        <Navbar bg="dark" variant="dark" expand="lg" collapseOnSelect>
            <Container>
                <LinkContainer container="nav" to="/">
                <Navbar.Brand>
                    <img src={logo} alt="logo" width="30" height="30" className="d-inline-block align-top" />{' '}
                    Microshop
                </Navbar.Brand>
                </LinkContainer>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ms-auto">
                        <LinkContainer container="nav" to="/cart">
                        <Nav.Link ><FaShoppingCart />Cart</Nav.Link>
                        </LinkContainer>
                        <LinkContainer container="nav" to="/signin">
                        <Nav.Link ><FaUser />Sign In</Nav.Link>
                        </LinkContainer>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    </header>
  )
}

export default Header