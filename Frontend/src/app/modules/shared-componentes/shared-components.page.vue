<template>
  <div>
    <!-- Lista de Botones -->
    <div class="container-components btn-container">
      <h2>Botones</h2>
      <div class="list">
        <ButtonShared
          class="btn"
          :text="'Ingresar'"
          :type="'large'"
          :bgColor="'red'"
          :loading="loading_button1"
          @Event="event"
        ></ButtonShared>
        <ButtonShared
          class="btn"
          :text="'Ingresar'"
          :type="'large'"
          :bgColor="'red'"
          :loading="loading_button2"
          @Event="event"
        ></ButtonShared>
        <ButtonShared
          class="btn"
          :text="'Cargando'"
          :type="'small'"
          :bgColor="'yellow'"
          :loading="loading_button2"
          @Event="event"
        ></ButtonShared>
      </div>
    </div>

    <!-- Lista de Inputs -->
    <div class="container-components">
      <h2>Input</h2>

      <div class="input-shared-container margin">
        <label class="label-shared-component">Dni</label>
        <input class="input-shared-component" type="text" v-model="inputVal1" />
      </div>

      <div class="input-shared-container margin">
        <label class="label-shared-component">Name</label>
        <input class="input-shared-component" type="text" v-model="inputVal2" />
      </div>
      <!-- </div>
      <InputShared
        :labelText="'DNI'"
        :model ="inputVal1"
        :labelAlign="'left'"
      ></InputShared>
    </div> -->
    </div>

    <!-- Lista de botones para abrir Modales -->
    <div class="container-components">
      <h2>Modales</h2>
      <div class="list-container-button-modal">
        <ButtonShared
          class="btn"
          :text="'Error Modal'"
          :type="'large'"
          :bgColor="'red'"
          @Event="showModalError"
        ></ButtonShared>

        <ButtonShared
          class="btn"
          :text="'Confirmación'"
          :type="'small'"
          :bgColor="'yellow'"
          @Event="confirmationModal"
        ></ButtonShared>

        <ButtonShared
          class="btn"
          :text="'Entendido'"
          :type="'small'"
          :bgColor="'yellow'"
          @Event="warningModal"
        />
      </div>
    </div>

    <div class="container-components">
      <h2>Barras horizontales</h2>
      <HorizontalBarShared
          :cards="dataHorizontaBar"
      />
    </div>
    <!-- Modal de error -->
    <ErrorModalShared
      @Event="closeModal"
      v-if="isShowModalError"
      :title="'Lo sentimos'"
      :description="
        'El grupo familiar X no existe o no está permitido el envío de solicitud en este momento'
      "
    ></ErrorModalShared>

    <!-- Modal de confirmación -->
    <ConfirmationModalShared
      @YesEvent="positiveDecision"
      @NoEvent="negativeDecision"
      v-if="isShowConfirmationModal"
      :title="'Confirmación'"
      :description="'¿Desea realmente abandonar el grupo?'"
    />

    <WarningModalShared
      @CloseModal="closeWarningModal"
      v-if="isShowWarningModal"
      :description="'Debe asignar a otro administrador para poder salir del grupo familiar'"

    />
  </div>
</template>

<script>
import ButtonShared from "../../shared/button/button.component.vue";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";
import ConfirmationModalShared from "../../shared/modal/confirmation-modal.component.vue";
import WarningModalShared from "../../shared/modal/warning-modal.component.vue";
import HorizontalBarShared from "../../shared/charts/horizontal-bar.component.vue";
export default {
  name: "SharedPageComponent",
  components: {
    ButtonShared,
    ErrorModalShared,
    ConfirmationModalShared,
    WarningModalShared,
    HorizontalBarShared
  },

  data: function() {
    return {
      loading_button1: false,
      loading_button2: true,
      inputVal1: "",
      inputVal2: "",
      isShowModalError: false,
      isShowConfirmationModal: false,
      isShowWarningModal: false,
      dataHorizontaBar:[
        {text: "2kg", color: "red", value: 2},
        {text: "1kg", color: "orange", value: 1},
      ]
    };
  },
  methods: {
    event() {
      this.$data.loading_button1 = true;
    },
    showModalError() {
      console.log("Mostrando modal");
      this.$data.isShowModalError = true;
    },
    closeModal() {
      this.$data.isShowModalError = false;
    },

    confirmationModal() {
      this.$data.isShowConfirmationModal = true;
    },
    negativeDecision() {
      this.$data.isShowConfirmationModal = false;
    },
    positiveDecision() {
      this.$data.isShowConfirmationModal = false;
    },

    warningModal() {
      this.$data.isShowWarningModal = true;
    },
    closeWarningModal() {
      this.$data.isShowWarningModal = false;
    },
  },
};
</script>

<style>
.margin {
  margin: 24px 0;
}
.container-components {
  width: 100vw;
  padding: 32px;
}

.btn-container .list {
  display: flex;
  justify-content: flex-start;
  align-items: center;
}
.btn {
  margin: 24px 24px 0 0;
}

.list-container-button-modal {
  display: flex;
}
</style>
