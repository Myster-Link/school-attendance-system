import Swal from "sweetalert2";

export const useAlert = () => {
  const deleteAlert = async () => {
    const result = await Swal.fire({
      title: "Estás seguro?",
      text: "La eliminación será permanente!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Sí, Eliminar!",
      cancelButtonText: "Cancelar",
      reverseButtons: true,
      customClass: {
        confirmButton: "confirm-button",
        cancelButton: "cancel-button",
      },
    });

    return result.isConfirmed;
  };

  const swalAlert = async (
    title: string,
    text: string,
    confirm: string,
    cancel: string,
    icon: "warning" | "error" | "info" | "success" = "warning"
  ) => {
    const result = await Swal.fire({
      title: title,
      text: text,
      icon: icon,
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: confirm,
      cancelButtonText: cancel,
      reverseButtons: true,
      customClass: {
        confirmButton: "confirm-button",
        cancelButton: "cancel-button",
      },
    });

    return result.isConfirmed;
  };

  const swalError = async (title: string, errors: string[] | string) => {
    function generateErrorList(errors: string[] | string): string {
      if (Array.isArray(errors)) {
        return `${errors.map((error) => `<p>${error}</p>`).join("")}`;
      } else {
        return `<p>${errors}</p>`;
      }
    }

    const errorListHTML = generateErrorList(errors);

    await Swal.fire({
      icon: "error",
      title: title,
      html: errorListHTML,
      customClass: {
        confirmButton: "confirm-button",
      },
    });
  };

  const swalInfo = async (text: string) => {
    await Swal.fire({
      icon: "info",
      title: "Oops...",
      text: text,
      customClass: {
        confirmButton: "confirm-button",
        cancelButton: "cancel-button",
      },
    });
  };

  const swalSuccess = async (title: string, text: string) => {
    await Swal.fire({
      icon: "success",
      title: title,
      text: text,
    });
  };

  const swalInfoSuccess = async (
    title: string,
    cancelBtn: string,
    confirmBtn: string
  ) => {
    const result = await Swal.fire({
      title: title,
      icon: "success",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: confirmBtn,
      cancelButtonText: cancelBtn,
      reverseButtons: true,
      customClass: {
        confirmButton: "confirm-button",
        cancelButton: "cancel-button",
      },
    });

    return result.isConfirmed;
  };

  const passwordPrompt = async () => {
    const result = await Swal.fire({
      title: "Ingrese su contraseña",
      input: "password",
      inputPlaceholder: "Ingrese su contraseña",
      showCancelButton: true,
      confirmButtonText: "Confirmar",
      cancelButtonText: "Cancelar",
      reverseButtons: true,
      preConfirm: (password) => {
        return password;
      },
    });

    return {
      isConfirmed: result.isConfirmed,
      password: result.value || "", // Handle null case if value is null
    };
  };

  return {
    deleteAlert,
    swalAlert,
    swalError,
    swalInfo,
    swalSuccess,
    swalInfoSuccess,
    passwordPrompt,
  };
};
