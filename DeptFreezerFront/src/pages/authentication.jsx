import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { login, register } from '../redux/actions/authActions';
import {
  Box,
  Button,
  TextField,
  Typography,
  Paper,
  Link
} from '@mui/material';


const Authentication = () => {
    const [fullName, setFullName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [isSignup, setIsSignup] = useState(false);
    const dispatch = useDispatch();

    const handleSubmit = (e) => {
        e.preventDefault();
        if (isSignup) dispatch(register({ fullName, email, password }));
        else dispatch(login({ email, password }));
    };

    return (
        <Box
            display="flex"
            justifyContent="center"
            alignItems="center"
            minHeight="100vh"
            bgcolor="#f5f5f5"
            >
            <Paper elevation={4} sx={{ p: 4, width: 380 }}>
                <Typography variant="h5" textAlign="center" mb={3}>
                {isSignup ? "Créer un compte" : "Connexion"}
                </Typography>

                <form onSubmit={handleSubmit}>
                {isSignup && (
                    <TextField
                    label="Nom complet"
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    value={fullName}
                    onChange={(e) => setFullName(e.target.value)}
                    required
                    />
                )}

                <TextField
                    label="Email"
                    type="email"
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />

                <TextField
                    label="Mot de passe"
                    type="password"
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />

                <Button
                    type="submit"
                    variant="contained"
                    fullWidth
                    sx={{ mt: 2 }}
                >
                    {isSignup ? "S'inscrire" : "Se connecter"}
                </Button>
                </form>

                <Typography textAlign="center" mt={2}>
                {isSignup ? "Déjà un compte ?" : "Pas encore de compte ?"}{" "}
                <Link
                    component="button"
                    variant="body2"
                    onClick={() => setIsSignup(!isSignup)}
                >
                    {isSignup ? "Se connecter" : "Créer un compte"}
                </Link>
                </Typography>
            </Paper>
        </Box>
    );
}
 
export default Authentication;