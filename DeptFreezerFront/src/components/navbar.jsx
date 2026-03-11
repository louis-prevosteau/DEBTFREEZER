import React from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";
import { useNavigate } from "react-router-dom";

export default function Navbar() {
  const navigate = useNavigate();

  const isAuthenticated = !!localStorage.getItem("token");

  const handleLogout = () => {
    localStorage.removeItem("token");
    navigate("/auth");
  };

  return (
    <AppBar position="static">
      <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
        
        <Box>
          <Button color="inherit" onClick={() => navigate("/")}>
            Dettes
          </Button>
          <Button color="inherit" onClick={() => navigate("/challenges")}>
            Défis
          </Button>
        </Box>

        <Box>
          {isAuthenticated ? (
            <Button color="inherit" onClick={handleLogout}>
              Déconnexion
            </Button>
          ) : (
            <Button color="inherit" onClick={() => navigate("/auth")}>
              Inscriptionn / Connexion
            </Button>
          )}
        </Box>

      </Toolbar>
    </AppBar>
  );
}