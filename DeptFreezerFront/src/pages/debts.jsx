import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { deleteDebt, getDebts } from "../redux/actions/debtActions";

import { useNavigate } from "react-router-dom";

import {
  Container,
  Typography,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  Button,
  Box
} from "@mui/material";

import DeleteIcon from "@mui/icons-material/Delete";
import AddIcon from "@mui/icons-material/Add";

function Debts() {
  const { debts } = useSelector((state) => state);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    dispatch(getDebts());
  }, [dispatch]);

  const handleDeleteDebt = (id) => {
    dispatch(deleteDebt(id));
  };

  const handleCreateDebt = () => {
    navigate("/create-debt");
  };

  return (
    <Container maxWidth="md">
      <Box
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
          mb: 3
        }}
      >
        <Typography variant="h4">
          Liste des dettes
        </Typography>

        <Button
          variant="contained"
          startIcon={<AddIcon />}
          onClick={handleCreateDebt}
        >
          Ajouter une dette
        </Button>
      </Box>

      <Paper elevation={3}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Nom</TableCell>
              <TableCell>Montant</TableCell>
              <TableCell>Date</TableCell>
              <TableCell align="right">Action</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {debts && debts.length > 0 ? (
              debts.map((debt) => (
                <TableRow key={debt._id}>
                  <TableCell>{debt.name}</TableCell>
                  <TableCell>{debt.amount} €</TableCell>
                  <TableCell>{debt.date}</TableCell>
                  <TableCell align="right">
                    <IconButton
                      color="error"
                      onClick={() => handleDeleteDebt(debt._id)}
                    >
                      <DeleteIcon />
                    </IconButton>
                  </TableCell>
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={4} align="center">
                  Aucune dette trouvée
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </Paper>
    </Container>
  );
}

export default Debts;