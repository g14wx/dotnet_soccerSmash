<template>
  <profile-card-component :team="team" :innerList="teamPlayers" :ftitle="'Players'">
  <template v-slot:button>
    <button
        class="bg-green-500 active:bg-green-600 uppercase text-white font-bold hover:shadow-md shadow text-xs px-4 py-2 rounded outline-none focus:outline-none sm:mr-2 mb-1"
        type="button"
        style="transition: all 0.15s ease 0s;"
        @click="showForm = !showForm"
    >
      Edit
    </button>
  </template>
    <template v-slot:body>
      <form v-if="showForm" method="post" action="/teams" @submit="validateForm">
        <form id="form" class=" mx-auto bg-white shadow rounded" method="post" action="/teams" @submit="validateForm" enctype="multipart/form-data">
          <div class="xl:w-full border-b border-gray-300 dark:border-gray-700 py-5">
            <div class="flex items-center w-11/12 mx-auto">
              <p class="text-lg text-gray-800 dark:text-gray-100 font-bold">Team's Information</p>
              <input type="hidden" name="Id" v-model="theTeam.Id">
              <input type="hidden" name="Img" v-model="theTeam.Img">
              <div class="ml-2 cursor-pointer text-gray-600 dark:text-gray-400">
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="16" height="16">
                  <path class="heroicon-ui" d="M12 22a10 10 0 1 1 0-20 10 10 0 0 1 0 20zm0-2a8 8 0 1 0 0-16 8 8 0 0 0 0 16zm0-9a1 1 0 0 1 1 1v4a1 1 0 0 1-2 0v-4a1 1 0 0 1 1-1zm0-4a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" fill="currentColor" />
                </svg>
              </div>
            </div>
          </div>
          <div class="w-11/12 mx-auto">
            <div class="container mx-auto">
              <div class="my-8 mx-auto xl:w-full xl:mx-0">
                <div class="xl:flex lg:flex md:flex flex-wrap justify-between">
                  <div class="xl:w-2/5 lg:w-2/5 md:w-2/5 flex flex-col mb-6">
                    <label for="TeamsName" class="pb-2 text-sm font-bold text-gray-800 dark:text-gray-100">Team's Name</label>
                    <input type="text" v-model="theTeam.Title" name="Title" required id="TeamsName" class="border border-gray-300 dark:border-gray-700 pl-3 py-3 shadow-sm rounded text-sm focus:outline-none bg-transparent focus:border-indigo-700 text-gray-800 dark:text-gray-100" placeholder="" />
                  </div>
                  <div class="xl:w-2/5 lg:w-2/5 md:w-2/5 flex flex-col mb-6">
                    <label for="ImageFile" class="pb-2 text-sm font-bold text-gray-800 dark:text-gray-100">Team's Logo</label>
                    <div class="h-16 w-16">
                      <img
                          alt="Team's img" ref="imgLoaded" class="h-full w-full rounded-full overflow-hidden shadow" v-if="url || theTeam.Id>0" id="imgLoad" :src="url.length > 0 ? url : theTeam.Id>0 ? '/Image/'+theTeam.Img : url"/>
                    </div>
                    <input type='file' name="ImageFile" ref="fileupload" id="ImageFile" @change="onFileChange" />
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="w-full py-4 sm:px-12 px-4 bg-gray-100 dark:bg-gray-700 mt-6 flex justify-end rounded-bl rounded-br">
            <div class="modal-close bg-red-700 transition duration-150 ease-in-out hover:bg-indigo-600 rounded text-white px-8 py-2 text-sm focus:outline-none mr-4" @click="onCancel">Cancel</div>
            <button class="bg-indigo-700 transition duration-150 ease-in-out hover:bg-indigo-600 rounded text-white px-8 py-2 text-sm focus:outline-none" type="submit">Save</button>
          </div>
        </form>

      </form>
    </template>
    <template v-slot:subtitle>
      FORMAL SOCCER TEAM
    </template>

    <template v-slot:loadMultiselect>
    <div>
      <div v-for="player in teamPlayers" class="inline-block my-7">
        <div class="bg-gray-900 shadow-lg rounded p-3 w-56 ">
          <div class="group relative">
            <img class="w-full md:w-72 block rounded" :src="'/Image/'+player.Img" alt="" />

            <div class="group relative">
              <form method="post" :action="'/player/delete/'+player.Id">
                <button type="submit" class="hover:scale-110 text-white opacity-0 transform translate-y-3 group-hover:translate-y-0 group-hover:opacity-100 transition">
                  <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 20 20" fill="red">
                    <path fill-rule="evenodd" d="M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z" clip-rule="evenodd" />
                  </svg>
                </button>
              </form>
          </div>
          </div>
          <div class="p-5">
            <h3 class="text-white text-lg">{{player.Name}}</h3>
            <p class="text-gray-400">{{player.NShirt}}</p>
          </div>
        </div>
      </div>
    </div>
    </template>
  </profile-card-component>
  
</template>

<script src="./EditComponent.ts">
</script>

<style scoped>

</style>