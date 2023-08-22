import { useNavigate } from 'react-router-dom';
import { LinkContainer } from 'react-router-bootstrap';

import { Badge, Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';
import { FaShoppingCart, FaUser } from 'react-icons/fa';
import { BsChatDots } from 'react-icons/bs';
import { useSelector, useDispatch } from 'react-redux';
import logo from '../../assets/logo.png';
import { useLogoutMutation } from '../../slices/usersApiSlice';
import { logout } from '../../slices/authSlice';

const Header = () => {
  const { cartItems } = useSelector((state) => state.cart); // cart property is set in the store
  const { userInfo } = useSelector((state) => state.auth);

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [logoutApiCall] = useLogoutMutation();

  const logoutHandler = async () => {
    try {
      await logoutApiCall().unwrap();
      dispatch(logout());
      navigate('/login');
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <>
      <header>
        <Navbar bg="dark" variant="dark" expand="lg" collapseOnSelect>
          <Container>
            <LinkContainer container="nav" to="/">
              <Navbar.Brand>
                <img
                  src={logo}
                  alt="logo"
                  width="30"
                  height="30"
                  className="d-inline-block align-top"
                />{' '}
                Microshop
              </Navbar.Brand>
            </LinkContainer>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
              <Nav className="ms-auto">
                <LinkContainer container="nav" to="/cart">
                  <Nav.Link>
                    <FaShoppingCart />
                    {/* Cart */}
                    {cartItems.length > 0 && (
                      <Badge pill bg="success" style={{ marginLeft: '5px' }}>
                        {cartItems.reduce((a, c) => a + c.qty, 0)}
                      </Badge>
                    )}
                  </Nav.Link>
                </LinkContainer>
                {userInfo ? (
                  <NavDropdown
                    dropdown="true"
                    title={userInfo.name}
                    id="username"
                  >
                    <LinkContainer container="nav" to="/profile">
                      <NavDropdown.Item>Profile</NavDropdown.Item>
                    </LinkContainer>
                    <NavDropdown.Item onClick={logoutHandler}>
                      Logout
                    </NavDropdown.Item>
                  </NavDropdown>
                ) : (
                  <>
                    <LinkContainer container="nav" to="/login">
                      <Nav.Link>
                        <FaUser />
                      </Nav.Link>
                    </LinkContainer>
                    <LinkContainer container="nav" to="/chat">
                      <Nav.Link>
                        <BsChatDots />
                      </Nav.Link>
                    </LinkContainer>
                  </>
                )}
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>
      </header>
    </>
  );
};

export default Header;
